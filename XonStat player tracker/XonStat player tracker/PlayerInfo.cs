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
    public partial class PlayerInfo : Form
    {
        // Player reference
        public Player Player;

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public PlayerInfo() => InitializeComponent();

        public PlayerInfo(Player player)
        {
            this.Player = player;
            InitializeComponent();
        }

        // Starting worker thread
        private void PlayerInfo_Load(object sender, EventArgs e)
        {
            var token = tokenSource.Token;
            task = new Task(() => LoadPlayerInfo(token));
            task.Start();
        }

        // Showing errors after loading
        private void PlayerInfo_Shown(object sender, EventArgs e) => Overview.ShowErrors();

        // Loading player info
        private void LoadPlayerInfo(CancellationToken token)
        {
            try
            {
                this.Player.LoadAll();
                // Printing out variables
                this.Invoke(new Action(() => { 
                    this.id.Text = this.Player.ID.ToString();
                    this.nickname.Text = this.Player.Nickname;
                    this.name.Text = this.Player.Name;
                    this.active.Text = this.Player.Active;
                    this.since.Text = this.Player.Since;
                    this.time.Text = this.Player.Time;
                }));
                LoadPlayerNames(token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            this.Invoke(new Action(() => { Overview.ShowErrors(); }));
        }

        // Getting recently used names
        private void LoadPlayerNames(CancellationToken token)
        {
            Dictionary<string, int> usedNames = new Dictionary<string, int>();
            var htmlWeb = new HtmlWeb();
            var gameList = htmlWeb.Load("https://stats.xonotic.org/games?player_id=" + this.Player.ID.ToString() + "&game_type_cd=overall");
            var gameLinks = gameList.DocumentNode.SelectNodes("//td[@class='text-center']/a[@class='button tiny']");
            if(gameLinks != null)
                foreach (var gameLink in gameLinks)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    var game = htmlWeb.Load("https://stats.xonotic.org" + gameLink.Attributes["href"].Value);
                    var playerLink = game.DocumentNode.SelectSingleNode("//a[@href='/player/" + this.Player.ID.ToString() + "']");
                    string usedName = null;
                    if (playerLink != null)
                        usedName = WebUtility.HtmlDecode(playerLink.InnerText).Trim();
                    // Updating dictionary
                    if ((usedName != null) && usedNames.ContainsKey(usedName))
                        usedNames[usedName]++;
                    else if (usedName != null)
                        usedNames.Add(usedName, 1);
                }
            PrintPlayerNames(usedNames);
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

        private void PlayerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
            Overview.OpenForms.Remove(this);
        }
    }
}
