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
        // Player reference
        public Player Player;

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;

        public PlayerInfo(Player player)
        {
            this.Player = player;
            this.token = this.tokenSource.Token;
            InitializeComponent();
            InitializeStatus();
        }

        // Starting worker thread
        private void PlayerInfo_Load (object sender, EventArgs e)
        {
            this.task = new Task(() => LoadPlayerInfo());
            this.task.Start();
        }

        // Loading player info
        private void LoadPlayerInfo ()
        {
            this.Invoke(new Action(() => { ChangeStatusMessage("Loading player info from his profile..."); }));
            this.Player.LoadAll();
            this.token.ThrowIfCancellationRequested();
            PrintPlayerVariables();
            LoadPlayerNames();
        }

        // Printing out variables
        private void PrintPlayerVariables ()
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
                    ResultStatusMessage("Successfully loaded information from player profile.", true);
                else
                    ResultStatusMessage("Some issues occured when loading information from player profile.", false);
            }));
        }

        // Getting recently used names
        private void LoadPlayerNames()
        {
            try
            {
                Thread.Sleep(1000);
                this.token.ThrowIfCancellationRequested();
                this.Invoke(new Action(() => { ChangeStatusMessage("Loading recently used names..."); }));
                int current = 0;
                int correct = 0;
                Dictionary<string, int> usedNames = new Dictionary<string, int>();
                var htmlWeb = new HtmlWeb();
                var gameList = htmlWeb.Load("https://stats.xonotic.org/games?player_id=" + this.Player.ID.ToString() + "&game_type_cd=overall");
                var gameLinks = gameList.DocumentNode.SelectNodes("//td[@class='text-center']/a[@class='button tiny']");
                if (gameLinks != null)
                { 
                    foreach (var gameLink in gameLinks)
                    {
                        this.token.ThrowIfCancellationRequested();
                        Thread.Sleep(200);
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
                        this.Invoke(new Action(() => { 
                            ChangeStatusProgress(current, correct, gameLinks.Count);
                        }));
                        PrintPlayerNames(usedNames);
                    }
                    this.Invoke(new Action(() => { ResultStatusMessage("Finished loading recently used names", correct, gameLinks.Count); }));
                }
                // Getting new gameList URL
                /*var newGameListURL = gameList.DocumentNode.SelectSingleNode("//div[@class='cell small-12']/a");
                if (newGameListURL != null)
                    gameListURL = "https://stats.xonotic.org" + WebUtility.HtmlDecode(newGameListURL.Attributes["href"].Value);*/
            }
            catch (OperationCanceledException) {}
        }

        // Printing out Dictionary that contains player names
        private void PrintPlayerNames(Dictionary<string, int> usedNames)
        {
            // Dictionary to string
            string names = "";
            foreach (KeyValuePair<string, int> usedName in usedNames)
                names += usedName.Key + " (" + usedName.Value.ToString() + ")\n";
            // Printing out variables
            this.Invoke(new Action(() => {
                this.names.Text = names;
            }));
        }

        // If the close button has been already pressed
        private bool CanClose = false;

        // Waiting for task to finish before closing a window
        private void PlayerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.CanClose)
            {
                e.Cancel = true;
                ClosingStatusMessage();
                this.tokenSource.Cancel();
                this.task.ContinueWith(t =>
                {
                    this.tokenSource.Dispose();
                    Overview.OpenForms.Remove(this);
                    this.CanClose = true;
                    this.Invoke(new Action(() => {
                        this.Close();
                    }));
                });
            }
        }
    }
}
