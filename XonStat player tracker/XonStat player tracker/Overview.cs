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
    public partial class Overview : Form
    {
        // List of players
        private List<Player> PlayerList = new List<Player>();

        // List of startup errors
        public static List<string> StartupErrors = new List<string>();

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public Overview() => InitializeComponent();

        private void Overview_Load(object sender, EventArgs e)
        {
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
            foreach (string id in playerList.AllKeys)
            {
                Player player = new Player(id);
                players.Rows.Add(new object[] { player.ID, player.LoadNickname() });
                PlayerList.Add(player);
            }
            // Starting worker thread
            var token = tokenSource.Token;
            task = new Task(() => LoadInfoFromProfiles(token));
            task.Start();
        }

        // Runs after _Load()
        private void Overview_Shown(object sender, EventArgs e)
        {
            // Showing startup errors
            string errorMessage = "";
            if (StartupErrors.Count > 0)
                for(int i = 0; i < StartupErrors.Count; i++)
                    errorMessage += "\n" + (i + 1).ToString() + ") " + StartupErrors[i];
            if (errorMessage != "")
                MessageBox.Show("These errors were found while loading this form:" + errorMessage, "XonStat player tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    player.LoadProfile();
                    // FInding a row that contains info about the player (in case they get shuffled)
                    int row = -1;
                    foreach (DataGridViewRow playerRow in players.Rows)
                    {
                        if (playerRow.Cells[0].Value.ToString().Equals(player.ID.ToString()))
                        {
                            row = playerRow.Index;
                            break;
                        }
                    }
                    // Printing out player info
                    if (row >= 0)
                    {
                        players.Rows[row].Cells[2].Value = player.LoadName();
                        players.Rows[row].Cells[3].Value = player.LoadActive();
                    }
                }
            }
            catch (OperationCanceledException) {}
        }

        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
        }
    }
}
