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
            this.token = this.tokenSource.Token;
            InitializeComponent();
            InitializeStatus(this.statusLabel);
        }

        // Creating new task while loading
        private void AddPlayer_Load(object sender, EventArgs e)
        {
            task = new Task(() =>
            {
                this.Invoke(new Action(() => {
                    Status_ChangeMessage("Waiting for input...");
                }));
            });
            task.Start();
        }

        //################################################################################
        //###############################  ELEMENT EVENTS  ###############################
        //################################################################################

        // Starting the process of adding new player in a Task
        private void addButton_Click(object sender, EventArgs e)
        {
            task.ContinueWith(t =>
            {
                AddPlayer_Validate();
            });
        }

        // Validating inputs + adding new player
        private void AddPlayer_Validate()
        {
            this.token.ThrowIfCancellationRequested();
            this.Invoke(new Action(() => {
                this.addButton.Enabled = false;
            }));
            string id = this.id.Text;
            string nickname = this.nickname.Text;
            if (id != null && id.Length > 0 && nickname != null && nickname.Length > 0)
            {
                int ID;
                if(Int32.TryParse(id, out ID))
                    if(ID > 0)
                    {
                        bool playerExists = (Overview.PlayerList.Where(x => ID == x.ID).ToList().Count > 0);
                        this.token.ThrowIfCancellationRequested();
                        if (!playerExists)
                        {
                            AddPlayer_Create(ID, nickname);
                            task.ContinueWith(t =>
                            {
                                this.Invoke(new Action(() =>
                                {
                                    this.Close();
                                }));
                            });
                        }
                        else
                            this.Invoke(new Action(() => {
                                Status_ResultMessage("This ID is already in use", false);
                            }));
                    }
                    else
                        this.Invoke(new Action(() => {
                            Status_ResultMessage("ID has to be bigger than zero", false);
                        }));
                else
                    this.Invoke(new Action(() => {
                        Status_ResultMessage("ID has to be an integer", false);
                    }));
            }
            else
                this.Invoke(new Action(() => {
                    Status_ResultMessage("Fields cannot be empty", false);
                }));
            this.Invoke(new Action(() => {
                this.addButton.Enabled = true;
            }));
        }

        // Creating new player
        private void AddPlayer_Create (int ID, string nickname)
        {
            // Adding the player into Appconfig
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(ID.ToString(), nickname);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            // Adding player into DataGridView
            this.Invoke(new Action(() => {
                Player player = this.Overview.PlayerList_CreatePlayer(ID);
                this.Overview.task.ContinueWith(t =>
                {
                    this.Overview.PlayerList_PrintInfo(player, true);
                });
                this.Overview.Status_ChangeMessage("New player \"" + nickname + "\" (ID = " + player.ID.ToString() + ") added. Loading player profile...");
            }));
        }

        //################################################################################
        //################################  CLOSING FORM  ################################
        //################################################################################

        // If the close button has been already pressed
        private bool CanClose = false;

        // Waiting for task to finish before closing a window
        private void AddPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.CanClose)
            {
                e.Cancel = true;
                Status_ClosingMessage();
                this.tokenSource.Cancel();
                task.ContinueWith(t =>
                {
                    this.tokenSource.Dispose();
                    this.Overview.AddPlayerWindow = null;
                    this.CanClose = true;
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                });
            }
        }
    }
}
