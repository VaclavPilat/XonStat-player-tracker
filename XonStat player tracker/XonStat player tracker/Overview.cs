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
        public Overview()
        {
            this.token = this.tokenSource.Token;
            InitializeComponent();
            InitializeStatus(this.statusLabel);
        }

        // Finding a row that contains info about the player (in case they get shuffled)
        private int GetGridRowIndex(Player player)
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

        // Change row color (only affects text cells)
        private void ChangeRowBackColor(DataGridViewRow dataRow, Color color)
        {
            foreach (DataGridViewCell dataCell in dataRow.Cells)
                if (dataCell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
                    dataCell.Style.BackColor = color;
        }

        //################################################################################
        //#############################  LOADING PLAYERLIST  #############################
        //################################################################################

        // List of players
        public List<Player> PlayerList = new List<Player>();

        private void Overview_Load(object sender, EventArgs e) => PlayerList_LoadPlayers();

        // Loding players from appsettings
        public void PlayerList_LoadPlayers ()
        {
            Status_ChangeMessage("Loading players from AppSettings...");
            var playerList = ConfigurationManager.AppSettings;
            int current = 0;
            foreach (string stringID in playerList.AllKeys)
            {
                current++;
                int intID;
                if (Int32.TryParse(stringID, out intID))
                    PlayerList_CreatePlayer(intID);
                Status_ChangeProgress(current, PlayerList.Count, playerList.Count);
            }
            Status_ResultMessage("Finished loading players from Appsettings", PlayerList.Count, playerList.Count);
            // Starting worker thread
            task = new Task(() => PlayerList_LoadProfiles());
            task.Start();
        }

        // Creates new player instnce and adds it to list of players
        public Player PlayerList_CreatePlayer (int ID)
        {
            Player player = new Player(ID);
            player.LoadNickname();
            players.Rows.Add(new object[] { player.ID, player.Nickname });
            PlayerList.Add(player);
            return player;
        }

        private Color rowColor;

        // Showing plyer info in DataGridView
        public void PlayerList_PrintInfo (Player player)
        {
            // Loading player profile
            player.LoadProfile();
            int row = GetGridRowIndex(player);
            if (player.Correct)
            {
                // Printing out player info
                if (row >= 0)
                {
                    player.LoadName();
                    players.Rows[row].Cells["name"].Value = player.Name;
                    player.LoadActive();
                    players.Rows[row].Cells["active"].Value = player.Active;
                    players.Rows[row].Cells["active"].Style = new DataGridViewCellStyle { ForeColor = player.GetActiveColor() };
                }
            }
            ChangeRowBackColor(players.Rows[row], this.rowColor);
        }

        // Loading all player profiles
        private void PlayerList_LoadProfiles()
        {
            this.Invoke(new Action(() => {
                this.addPlayer.Enabled = false;
                this.refreshList.Enabled = false;
            }));
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
                    // Changing row color
                    int row = GetGridRowIndex(player);
                    if (row >= 0)
                    {
                        this.rowColor = players.Rows[row].DefaultCellStyle.BackColor;
                        ChangeRowBackColor(players.Rows[row], Color.Beige);
                    }
                    WaitForSeconds(0.25f);
                    // Loading player profile
                    current++;
                    PlayerList_PrintInfo(player);
                    if(player.Correct)
                        correct++;
                    this.Invoke(new Action(() => { 
                        Status_ChangeProgress(current, correct, PlayerList.Count); 
                    }));
                }
                this.Invoke(new Action(() => { 
                    Status_ResultMessage("Finished loading data from player profiles", correct, PlayerList.Count);
                    this.addPlayer.Enabled = true;
                    this.refreshList.Enabled = true;
                }));
            }
            catch (OperationCanceledException) { }
        }

        //################################################################################
        //#############################  PLAYERLIST EVENTS  ##############################
        //################################################################################

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
                        Player_ShowProfile(currentPlayer);
                        break;
                    case "info":
                        Player_ShowInfo(currentPlayer);
                        break;
                    case "delete":
                        Player_Delete(currentPlayer);
                        break;
                    default:
                        break;
                }
            }
        }

        // Deleting selected player
        private void Player_Delete(Player player)
        {
            if (task.IsCompleted)
                if (MessageBox.Show("Are you sure you want to delete player \"" + player.Nickname + "\" (ID = " + player.ID.ToString() + ") ?", 
                                    "XonStat player tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.task.ContinueWith(t =>
                    {
                        // Removing the player from DataGridView
                        int row = GetGridRowIndex(player);
                        this.Invoke(new Action(() => {
                            players.Rows.RemoveAt(row);
                            PlayerList.Remove(player);
                            this.Status_ResultMessage("Removed player \"" + player.Nickname + "\" (ID = " + player.ID + ") from Appconfig.", true);
                        }));
                        // Removing the player from Appconfig
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings.Remove(player.ID.ToString());
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    });
        }

        // Showing player profile in a browser
        private void Player_ShowProfile(Player currentPlayer)
        {
            Process.Start(new ProcessStartInfo(currentPlayer.ProfileURL())
            { // https://stackoverflow.com/a/53245993
                UseShellExecute = true,
                Verb = "open"
            });
        }

        // List that contains currently open PlayerInfo forms
        public List<PlayerInfo> OpenForms = new List<PlayerInfo>();

        // Opening new PlayerInfo form
        private void Player_ShowInfo(Player currentPlayer)
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

        //################################################################################
        //###########################  OVERVIEW ELEMENT EVENTS  ##########################
        //################################################################################

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

        // Currently opened window for adding new player
        public AddPlayer AddPlayerWindow = null;

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

        // Refreshing player list
        private void refreshList_Click(object sender, EventArgs e)
        {
            if (task.IsCompleted)
                this.task.ContinueWith(t =>
                {
                    PlayerList_LoadProfiles();
                });
        }

        //################################################################################
        //################################  CLOSING FORM  ################################
        //################################################################################

        // Actions performed before closing the form
        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.tokenSource.Cancel();
            //task.Wait();
            //this.tokenSource.Dispose();
        }
    }
}
