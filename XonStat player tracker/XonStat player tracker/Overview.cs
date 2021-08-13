using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
    public partial class Overview : Form
    {
        // List of players
        private List<Player> PlayerList = new List<Player>();

        // List of startup errors
        public static ConcurrentQueue<string> Errors = new ConcurrentQueue<string>();

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        // List that contains currently open PlayerInfo forms
        public static List<PlayerInfo> OpenForms = new List<PlayerInfo>();

        public Overview() => InitializeComponent();

        private void Overview_Load(object sender, EventArgs e)
        {
            ChangeStatus("Loading players from AppSettings...");
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
            int current = 1;
            foreach (string stringID in playerList.AllKeys)
            {
                int intID;
                if (Int32.TryParse(stringID, out intID))
                {
                    Player player = new Player(intID);
                    player.LoadNickname();
                    players.Rows.Add(new object[] { player.ID, player.Nickname });
                    PlayerList.Add(player);
                }
                ChangeStatusProgress(current, PlayerList.Count, playerList.Count);
                current++;
            }
            ChangeStatus("Finished loading players from Appsettings", PlayerList.Count, playerList.Count);
            // Starting worker thread
            var token = tokenSource.Token;
            task = new Task(() => LoadInfoFromProfiles(token));
            task.Start();
        }

        // Runs after _Load()
        private void Overview_Shown(object sender, EventArgs e) => ShowErrors();

        // Showing multiple errors in one dialog
        public static void ShowErrors()
        {
            string errorMessage = "";
            if (Errors.Count > 0)
            {
                int index = 1;
                foreach (string error in Errors)
                {
                    errorMessage += "\n" + index.ToString() + ") " + error;
                    string removed;
                    Errors.TryDequeue(out removed);
                }
                MessageBox.Show("These issues were found while loading this form:" + errorMessage, "XonStat player tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            this.Invoke(new Action(() => { ChangeStatus("Loading player info from their profiles..."); }));
            int current = 1;
            int correct = 0;
            try
            {
                foreach (Player player in PlayerList)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    // Loading player profile
                    if (player.LoadProfile())
                    {
                        // Printing out player info
                        int row = GetGridRowIndex(player);
                        if (row >= 0)
                            if (player.LoadName())
                            {
                                players.Rows[row].Cells[GetGridColumnIndex("name")].Value = player.Name;
                                if (player.LoadActive())
                                    players.Rows[row].Cells[GetGridColumnIndex("active")].Value = player.Active;
                            }
                        correct++;
                    }
                    this.Invoke(new Action(() => { ChangeStatusProgress(current, correct, PlayerList.Count); }));
                    current++;
                    Thread.Sleep(500);
                }
            }
            catch (OperationCanceledException) 
            {
                return;
            }
            this.Invoke(new Action(() => { ChangeStatus("Finished loading data from player profiles", correct, PlayerList.Count); }));
        }

        // Actions performed before closing the form
        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
        }

        private string StatusMessage = null;

        // Changing form status message
        public void ChangeStatus (string message)
        {
            this.StatusMessage = message;
            this.status.Text = this.StatusMessage;
        }
        public void ChangeStatus (string message, int correct, int maximum)
        {
            this.StatusMessage = message + " (" + correct.ToString() + " successful out of " + maximum.ToString() + ")";
            this.status.Text = this.StatusMessage;
            if(correct == maximum)
                ChangeStatusColor(Color.LightGreen);
            else
                ChangeStatusColor(Color.LightSalmon);
        }

        // Changing status background color
        public void ChangeStatusColor(Color color)
        {
            this.status.BackColor = color;
        }

        // Changing form status progress
        public void ChangeStatusProgress (int current, int maximum)
        {
            this.status.Text = this.StatusMessage + " (" + current.ToString() + " out of " + maximum.ToString() + ")";
            ChangeStatusColor(Color.LightYellow);
        }
        public void ChangeStatusProgress(int current, int correct, int maximum)
        {
            this.status.Text = this.StatusMessage + " (" + current.ToString() + " out of " + maximum.ToString() + " done, " + correct.ToString() + " successful)";
            ChangeStatusColor(Color.LightYellow);
        }
    }
}
