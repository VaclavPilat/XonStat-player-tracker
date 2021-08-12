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

        public Overview() => InitializeComponent();

        private void Overview_Load(object sender, EventArgs e)
        {
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
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
                else
                    Overview.Errors.Enqueue("ID " + stringID + " - Not a valid player ID and cannot be added.");
            }
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
                        // Showing player profile in a browser
                        Process.Start(new ProcessStartInfo(currentPlayer.ProfileURL()) { // https://stackoverflow.com/a/53245993
                            UseShellExecute = true,
                            Verb = "open"
                        });
                        break;
                    case "info":
                        // Showing a form with more info about the player
                        PlayerInfo playerInfo = new PlayerInfo(currentPlayer);
                        playerInfo.Show();
                        break;
                    default:
                        break;
                }
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
                    }
                }
            }
            catch (OperationCanceledException) 
            {
                return;
            }
            this.Invoke(new Action(() => { ShowErrors(); }));
        }

        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
        }
    }
}
