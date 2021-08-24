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
using System.Net;
using HtmlAgilityPack;

namespace XonStat_player_tracker
{
    public partial class PlayerInfo : FormWithStatus
    {
        // Reference to Overview window instance
        private Overview Overview = null;

        // Player reference
        public Player Player;

        public PlayerInfo(Overview overview, Player player)
        {
            this.Overview = overview;
            this.Player = player;
            this.token = this.tokenSource.Token;
            InitializeComponent();
            InitializeStatus(this.statusLabel);
        }

        //################################################################################
        //#########################  LOADING PLAYER INFORMATION  #########################
        //################################################################################

        // Starting worker thread
        private void PlayerInfo_Load (object sender, EventArgs e)
        {
            this.task = new Task(() => Player_LoadProfile());
            this.task.Start();
        }

        // Loading player info
        private void Player_LoadProfile ()
        {
            this.Invoke(new Action(() => { Status_ChangeMessage("Loading player info from his profile..."); }));
            this.Player.LoadAll();
            this.token.ThrowIfCancellationRequested();
            Player_PrintVariables();
            if(this.Player.Correct)
                Player_LoadNames();
        }

        // Printing out variables
        private void Player_PrintVariables ()
        {
            this.Invoke(new Action(() => {
                this.id.Text = this.Player.ID.ToString();
                this.nickname.Text = this.Player.Nickname;
                this.name.Text = this.Player.Name;
                this.active.Text = this.Player.Active;
                this.active.ForeColor = this.Player.GetActiveColor();
                this.since.Text = this.Player.Since;
                this.time.Text = this.Player.Time;
                if (this.Player.Correct)
                    Status_ResultMessage("Successfully loaded information from player profile.", true);
                else
                    Status_ResultMessage("Some issues occured when loading information from player profile.", false);
            }));
        }

        // Getting recently used names
        private void Player_LoadNames()
        {
            try
            {
                WaitForSeconds(1);
                this.Invoke(new Action(() => { Status_ChangeMessage("Started loading recently used names..."); }));
                this.token.ThrowIfCancellationRequested();
                int current = 0;
                int correct = 0;
                int maximum = 0;
                Dictionary<string, int> usedNames = new Dictionary<string, int>();
                var htmlWeb = new HtmlWeb();
                string gameListURL = "https://stats.xonotic.org/games?player_id=" + this.Player.ID.ToString() + "&game_type_cd=overall";

                for (int i = 0; i < 5; i++)
                {
                    this.Invoke(new Action(() => { Status_ChangeMessage("Loading recently used names..."); }));
                    this.Invoke(new Action(() => { Status_ChangeProgress(current, correct, maximum); }));
                    var gameList = htmlWeb.Load(gameListURL);
                    var gameLinks = gameList.DocumentNode.SelectNodes("//td[@class='text-center']/a[@class='button tiny']");
                    if (gameLinks != null)
                    {
                        maximum += gameLinks.Count;
                        foreach (var gameLink in gameLinks)
                        {
                            try
                            {
                                WaitForSeconds(0.25f);
                                current++;
                                var game = htmlWeb.Load("https://stats.xonotic.org" + gameLink.Attributes["href"].Value);
                                var playerLink = game.DocumentNode.SelectSingleNode("//a[@href='/player/" + this.Player.ID.ToString() + "']");
                                string usedName = null;
                                if (playerLink != null)
                                    usedName = WebUtility.HtmlDecode(playerLink.InnerText).Trim();
                                // Updating dictionary
                                if (usedName != null)
                                {
                                    if (usedNames.ContainsKey(usedName))
                                        usedNames[usedName]++;
                                    else
                                        usedNames.Add(usedName, 1);
                                    correct++;
                                }
                            }
                            catch (WebException) { }
                            this.Invoke(new Action(() => { Status_ChangeProgress(current, correct, maximum); }));
                            Player_PrintNames(usedNames);
                        }
                        this.Invoke(new Action(() => { Status_ResultMessage("Finished loading recently used names", correct, maximum); }));
                    }
                    // If token is not cancelled, waits for 5 seconds
                    WaitForSeconds(5);
                    // Getting new gameList URL
                    var newGameListURL = gameList.DocumentNode.SelectSingleNode("//div[@class='cell small-12']/a");
                    if (newGameListURL != null)
                        gameListURL = "https://stats.xonotic.org" + WebUtility.HtmlDecode(newGameListURL.Attributes["href"].Value);
                    else
                        break;
                }
            }
            catch (OperationCanceledException) {}
        }

        // Printing out Dictionary that contains player names
        private void Player_PrintNames(Dictionary<string, int> usedNames)
        {
            // Dictionary to string
            string[] names = new string[usedNames.Count];
            int i = 0;
            foreach (KeyValuePair<string, int> usedName in usedNames)
            {
                names[i] = usedName.Key + " (" + usedName.Value.ToString() + ")\n";
                i++;
            }
            this.Invoke(new Action(() => { this.names.Lines = names; }));
        }

        //################################################################################
        //################################  CLOSING FORM  ################################
        //################################################################################

        // If the close button has been already pressed
        private bool CanClose = false;

        // Waiting for task to finish before closing a window
        private void PlayerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.CanClose)
            {
                e.Cancel = true;
                Status_ClosingMessage();
                this.tokenSource.Cancel();
                this.task.ContinueWith(t =>
                {
                    this.tokenSource.Dispose();
                    this.Overview.OpenForms.Remove(this);
                    this.CanClose = true;
                    this.Invoke(new Action(() => {
                        this.Close();
                    }));
                });
            }
        }
    }
}
