using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace XonStat_player_tracker
{
    public partial class AddPlayer : FormWithStatus
    {
        // Reference to Overview window instance
        private Overview Overview = null;

        public AddPlayer(Overview overview)
        {
            this.Overview = overview;
            InitializeComponent();
            InitializeStatus();
        }

        // Closing form after clicking on Caancel button
        private void cancelButton_Click(object sender, EventArgs e) => this.Close();

        // Closing form
        private void AddPlayer_FormClosing(object sender, FormClosingEventArgs e) => Overview.AddPlayerWindow = null;

        // Validating inputs + adding new player
        private void addButton_Click(object sender, EventArgs e)
        {
            this.addButton.Enabled = false;
            string id = this.id.Text;
            string nickname = this.nickname.Text;
            if (id != null && id.Length > 0 && nickname != null && nickname.Length > 0)
            {
                int ID;
                if(Int32.TryParse(id, out ID))
                    if(ID > 0)
                    {
                        bool playerExists = (Overview.PlayerList.Where(x => ID == x.ID).ToList().Count > 0);
                        if (!playerExists)
                        {
                            // Adding the player into Appconfig
                            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            config.AppSettings.Settings.Add(ID.ToString(), nickname);
                            config.Save();
                            ConfigurationManager.RefreshSection("appSettings");
                            int playerCount = this.Overview.PlayerList.Count;
                            Player player = this.Overview.CreatePlayerInstance(ID);
                            this.Overview.ShowPlayerInfo(player);
                            this.Overview.Status_ResultMessage("New player (ID = " + player.ID.ToString() + ") added. Loading player profile...", player.Correct);
                            this.Close();
                        }
                        else
                            Status_ResultMessage("This player ID is already in use", false);
                    }
                    else
                        Status_ResultMessage("Player ID has to be bigger than zero", false);
                else
                    Status_ResultMessage("Player ID has to be an integer", false);
            }
            else
                Status_ResultMessage("Fields cannot be empty", false);
            this.addButton.Enabled = true;
        }
    }
}
