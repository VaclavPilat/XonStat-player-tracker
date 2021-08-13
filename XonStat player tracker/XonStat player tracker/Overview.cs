using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace XonStat_player_tracker
{
    public partial class Overview : FormWithStatus
    {
        // List of players
        private List<Player> PlayerList = new List<Player>();

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        // List that contains currently open PlayerInfo forms
        public static List<PlayerInfo> OpenForms = new List<PlayerInfo>();

        public Overview()
        {
            InitializeComponent();
            InitializeStatus();
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            ChangeStatusMessage("Loading players from AppSettings...");
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
            int current = 0;
            foreach (string stringID in playerList.AllKeys)
            {
                current++;
                int intID;
                if (Int32.TryParse(stringID, out intID))
                {
                    Player player = new Player(intID);
                    player.LoadNickname();
                    players.Rows.Add(new object[] { player.ID, player.Nickname });
                    PlayerList.Add(player);
                }
                ChangeStatusProgress(current, PlayerList.Count, playerList.Count);
            }
            FinalStatusMessage("Finished loading players from Appsettings", PlayerList.Count, playerList.Count);
            // Starting worker thread
            var token = tokenSource.Token;
            task = new Task(() => LoadInfoFromProfiles(token));
            task.Start();
        }

        // Actions after clicking on a cell value
        private void players_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Disabling onclick actions for column headers
            {
                // Getting the correct Player object
                string playerID = players.Rows[e.RowIndex].Cells[0].Value.ToString();
                Player currentPlayer = PlayerList.Where(x => playerID.Contains(x.ID.ToString())).ToList().First();
                // Performing onclick actions
                switch (players.Columns[e.ColumnIndex].Name)
                {
                    case "profile":
                        ShowPlayerProfile(currentPlayer);
                        break;
                    case "info":
                        ShowPlayerInfo(currentPlayer);
                        break;
                    default:
                        break;
                }
            }
        }

        // Showing player profile in a browser
        private void ShowPlayerProfile (Player currentPlayer)
        {
            Process.Start(new ProcessStartInfo(currentPlayer.ProfileURL())
            { // https://stackoverflow.com/a/53245993
                UseShellExecute = true,
                Verb = "open"
            });
        }

        // Opening new PlayerInfo form
        private void ShowPlayerInfo (Player currentPlayer)
        {
            // Checking if there is already a form opened that contains the same player info
            PlayerInfo currentForm = null;
            foreach (PlayerInfo form in OpenForms)
                if (form.Player == currentPlayer)
                {
                    currentForm = form;
                    break;
                }
            if (currentForm != null)
                currentForm.BringToFront();
            else
            {
                // Showing a form with more info about the player
                PlayerInfo playerInfo = new PlayerInfo(currentPlayer);
                playerInfo.Show();
                OpenForms.Add(playerInfo);
            }
        }

        // Finding a row that contains info about the player (in case they get shuffled)
        private int GetGridRowIndex (Player player)
        {
            int row = -1;
            foreach (DataGridViewRow dataRow in players.Rows)
                if (dataRow.Cells[0].Value.ToString().Equals(player.ID.ToString()))
                {
                    row = dataRow.Index;
                    break;
                }
            return row;
        }

        // Getting index of a specified column
        private int GetGridColumnIndex (string name)
        {
            int column = -1;
            foreach (DataGridViewColumn dataColumn in players.Columns)
                if (dataColumn.Name.Equals(name))
                {
                    column = dataColumn.Index;
                    break;
                }
            return column;
        }

        // Loading all player profiles
        private void LoadInfoFromProfiles(CancellationToken token)
        {
            Thread.Sleep(1000);
            this.Invoke(new Action(() => { ChangeStatusMessage("Loading player info from their profiles..."); }));
            int current = 0;
            int correct = 0;
            try
            {
                foreach (Player player in PlayerList)
                {
                    current++;
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    else
                        Thread.Sleep(200);
                    // Loading player profile
                    player.LoadProfile();
                    if(player.Correct)
                    {
                        // Printing out player info
                        int row = GetGridRowIndex(player);
                        if (row >= 0)
                        { 
                            player.LoadName();
                            players.Rows[row].Cells[GetGridColumnIndex("name")].Value = player.Name;
                            player.LoadActive();
                            players.Rows[row].Cells[GetGridColumnIndex("active")].Value = player.Active;
                        }
                    }
                    if(player.Correct)
                        correct++;
                    this.Invoke(new Action(() => { ChangeStatusProgress(current, correct, PlayerList.Count); }));
                }
            }
            catch (OperationCanceledException) 
            {
                return;
            }
            this.Invoke(new Action(() => { FinalStatusMessage("Finished loading data from player profiles", correct, PlayerList.Count); }));
        }

        // Actions performed before closing the form
        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
        }
    }
}
