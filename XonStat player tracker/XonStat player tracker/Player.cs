using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using HtmlAgilityPack;

namespace XonStat_player_tracker
{
    public class Player
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        private HtmlAgilityPack.HtmlDocument Profile { get; set; }

        public Player() { }

        // Constructor with int ID
        public Player(int id) => this.ID = id;

        // Gets profile URL
        public string ProfileURL()
        {
            return "https://stats.xonotic.org/player/" + this.ID.ToString();
        }

        // Loads all variables
        public void LoadAll ()
        {
            LoadNickname();
            LoadName();
        }

        // Loads player nickname from Appconfig and returns it
        public string LoadNickname()
        {
            try
            {
                this.Nickname = ConfigurationManager.AppSettings[this.ID.ToString()];
            }
            catch
            {
                Overview.Errors.Enqueue("Cannot find player nickname using ID = " + this.ID.ToString());
            }
            return this.Nickname;
        }

        // Loads player profile
        public void LoadProfile()
        {
            try
            {
                // Getting HTML document using HtmlAgilityPack package
                var web = new HtmlWeb();
                this.Profile = web.Load(this.ProfileURL());
            }
            catch
            {
                Overview.Errors.Enqueue("Cannot load player profile (ID = " + this.ID.ToString() + ")");
            }
        }

        // Loads current player nickname and returns it
        public string LoadName()
        {
            try
            {
                this.Name = this.Profile.DocumentNode.SelectSingleNode("//h2").InnerText;
            }
            catch
            {
                if (this.Profile != null)
                    Overview.Errors.Enqueue("Cannot find player name (ID = " + this.ID.ToString() + ")");
            }
            return this.Name;
        }

        // Loads the last time a player was active
        public string LoadActive()
        {
            try
            {
                this.Active = this.Profile.DocumentNode.SelectNodes("//span[@class='abstime']")[1].InnerText;
            }
            catch
            { 
                if(this.Profile != null)
                    Overview.Errors.Enqueue("Cannot find the last time a player (ID = " + this.ID.ToString() + ") was active");
            }
            return this.Active;
        }
    }
}
