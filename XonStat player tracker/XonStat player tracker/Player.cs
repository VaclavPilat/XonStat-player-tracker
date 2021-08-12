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
        public string Since { get; set; }
        public string Time { get; set; }
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
            if (this.Since == null)
                this.LoadSince();
            if (this.Time == null)
                this.LoadTime();
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

        // Loads the time a player joined his first game
        public bool LoadSince()
        {
            bool response;
            try
            {
                this.Since = this.Profile.DocumentNode.SelectNodes("//span[@class='abstime']")[0].InnerText;
                response = true;
            }
            catch
            { 
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot find the time a player started playing");
                response = false;
            }
            return response;
        }

        // Loads the total time spent (in hours)
        public bool LoadTime()
        {
            bool response;
            try
            {
                string timePlayedString = this.Profile.DocumentNode.SelectNodes("//div[@class='cell small-6']/p")[1].InnerText.Trim();
                string timeString = timePlayedString.Split(": ")[1];
                string[] timeArray = timeString.Split(" ");
                int hours = 0;
                for (int i = 0; i < timeArray.Length; i += 2)
                    if (timeArray[i + 1].Contains("days"))
                        hours += Int32.Parse(timeArray[i]) * 24;
                    else if (timeArray[i + 1].Contains("hours"))
                        hours += Int32.Parse(timeArray[i]);
                this.Time = hours.ToString() + " hours";
                response = true;
            }
            catch
            { 
                Overview.Errors.Enqueue("ID " + this.ID.ToString() + " - Cannot find total time spent");
                response = false;
            }
            return response;
        }
    }
}
