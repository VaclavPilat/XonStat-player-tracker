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
            if (this.Nickname == null)
                this.LoadNickname();
            if (this.Profile == null)
                this.LoadProfile();
            if (this.Name == null)
                this.LoadName();
            if (this.Active == null)
                this.LoadActive();
        }

        // Loads player nickname from Appconfig
        public bool LoadNickname()
        {
            bool response;
            try
            {
                this.Nickname = ConfigurationManager.AppSettings[this.ID.ToString()];
                response = true;
            }
            catch
            {
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot find player nickname in a config file");
                response = false;
            }
            return response;
        }

        // Loads player profile
        public bool LoadProfile()
        {
            bool response;
            try
            {
                // Getting HTML document using HtmlAgilityPack package
                var web = new HtmlWeb();
                this.Profile = web.Load(this.ProfileURL());
                response = true;
            }
            catch
            {
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot load player profile");
                response = false;
            }
            return response;
        }

        // Loads current player nickname
        public bool LoadName()
        {
            bool response;
            try
            {
                this.Name = this.Profile.DocumentNode.SelectSingleNode("//div[@class='cell small-12']//h2").InnerText;
                response = true;
            }
            catch
            {
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot find player name. This player may not exist");
                response = false;
            }
            return response;
        }

        // Loads the last time a player was active
        public bool LoadActive()
        {
            bool response;
            try
            {
                this.Active = this.Profile.DocumentNode.SelectNodes("//span[@class='abstime']")[1].InnerText;
                response = true;
            }
            catch
            { 
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot find the last time a player was active");
                response = false;
            }
            return response;
        }
    }
}
