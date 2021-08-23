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
        public List<Player> PlayerList = new List<Player>();

        // List that contains currently open PlayerInfo forms
        public List<PlayerInfo> OpenForms = new List<PlayerInfo>();

        // Currently opened window for adding new player
        public AddPlayer AddPlayerWindow = null;

        public Overview()
        {
            this.token = this.tokenSource.Token;
            InitializeComponent();
            InitializeStatus();
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            Status_ChangeMessage("Loading players from AppSettings...");
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
            int current = 0;
            foreach (string stringID in playerList.AllKeys)
            {
                current++;
                int intID;
                if (Int32.TryParse(stringID, out intID))
                    CreatePlayerInstance(intID);
                Status_ChangeProgress(current, PlayerList.Count, playerList.Count);
            }
            Status_ResultMessage("Finished loading players from Appsettings", PlayerList.Count, playerList.Count);
            // Starting worker thread
            task = new Task(() => LoadInfoFromProfiles());
            task.Start();
        }

        // Creates new player instnce and adds it to list of players
        public Player CreatePlayerInstance (int ID)
        {
            Player player = new Player(ID);
            player.LoadNickname();
            players.Rows.Add(new object[] { player.ID, player.Nickname });
            PlayerList.Add(player);
            return player;
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
                        OpenPlayerInfo(currentPlayer);
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
        private void OpenPlayerInfo (Player currentPlayer)
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
                PlayerInfo playerInfo = new PlayerInfo(this, currentPlayer);
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

        // Showing plyer info in DataGridView
        public void ShowPlayerInfo (Player player)
        {
            // Loading player profile
            player.LoadProfile();
            if (player.Correct)
            {
                // Printing out player info
                int row = GetGridRowIndex(player);
                if (row >= 0)
                {
                    player.LoadName();
                    players.Rows[row].Cells["name"].Value = player.Name;
                    player.LoadActive();
                    players.Rows[row].Cells["active"].Value = player.Active;
                    players.Rows[row].Cells["active"].Style = new DataGridViewCellStyle { ForeColor = player.GetActiveColor() };
                }
            }
        }

        // Loading all player profiles
        private void LoadInfoFromProfiles()
        {
            WaitForSeconds(1);
            this.Invoke(new Action(() => { 
                Status_ChangeMessage("Loading player info from their profiles..."); 
            }));
            int current = 0;
            int correct = 0;
            try
            {
                foreach (Player player in PlayerList)
                {
                    WaitForSeconds(0.25f);
                    current++;
                    ShowPlayerInfo(player);
                    if(player.Correct)
                        correct++;
                    this.Invoke(new Action(() => { 
                        Status_ChangeProgress(current, correct, PlayerList.Count); 
                    }));
                }
                this.Invoke(new Action(() => { 
                    Status_ResultMessage("Finished loading data from player profiles", correct, PlayerList.Count);
                    this.addPlayer.Enabled = true;
                }));
            }
            catch (OperationCanceledException) { }
        }

        // Actions performed before closing the form
        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.tokenSource.Cancel();
            //task.Wait();
            //this.tokenSource.Dispose();
        }

        // Showing only rows that have set text in them
        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string text = this.searchBar.Text.ToLower();
            // Looping through each row
            foreach (DataGridViewRow dataRow in players.Rows)
            {
                bool containsText = false;
                // Looping through each cell in a row
                foreach(DataGridViewCell dataCell in dataRow.Cells)
                    if (dataCell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
                    {
                        string value = (dataCell.Value ?? string.Empty).ToString().ToLower();
                        if (value.Contains(text))
                        {
                            containsText = true;
                            break;
                        }
                    }
                dataRow.Visible = containsText;
            }
        }

        // Adding new player
        private void addPlayer_Click(object sender, EventArgs e)
        {
            if (AddPlayerWindow == null)
            {
                AddPlayerWindow = new AddPlayer(this);
                AddPlayerWindow.Show();
            }
            else
                AddPlayerWindow.BringToFront();
        }
    }
}
