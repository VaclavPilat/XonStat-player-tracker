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
        public bool Correct { get; set;}
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public string Since { get; set; }
        public string Time { get; set; }
        private HtmlAgilityPack.HtmlDocument Profile { get; set; }

        // Constructor with int ID
        public Player(int id)
        {
            this.ID = id;
            this.Correct = true;
        }

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
            if (this.Profile == null || !this.Correct)
                this.LoadProfile();
            if (this.Name == null || !this.Correct)
                this.LoadName();
            if (this.Active == null || !this.Correct)
                this.LoadActive();
            if (this.Since == null || !this.Correct)
                this.LoadSince();
            if (this.Time == null || !this.Correct)
                this.LoadTime();
        }

        // Loads player nickname from Appconfig
        public void LoadNickname()
        {
            try
            {
                this.Nickname = ConfigurationManager.AppSettings[this.ID.ToString()];
            }
            catch
            {
                this.Correct = false;
            }
        }

        // Loads player profile
        public void LoadProfile()
        {
            try
            {
                // Getting HTML document using HtmlAgilityPack package
                var web = new HtmlWeb();
                this.Profile = web.Load(this.ProfileURL());
                this.Correct = true;
            }
            catch
            {
                this.Correct = false;
            }
        }

        // Loads current player nickname
        public void LoadName()
        {
            try
            {
                string rawName = this.Profile.DocumentNode.SelectSingleNode("//div[@class='cell small-12']//h2").InnerText;
                this.Name = WebUtility.HtmlDecode(rawName);
            }
            catch
            {
                this.Correct = false;
            }
        }

        // Loads the last time a player was active
        public void LoadActive()
        {
            try
            {
                this.Active = this.Profile.DocumentNode.SelectNodes("//span[@class='abstime']")[1].InnerText;
            }
            catch
            {
                this.Correct = false;
            }
        }

        // Loads the time a player joined his first game
        public void LoadSince()
        {
            try
            {
                this.Since = this.Profile.DocumentNode.SelectNodes("//span[@class='abstime']")[0].InnerText;
            }
            catch
            {
                this.Correct = false;
            }
        }

        // Loads the total time spent (in hours)
        public void LoadTime()
        {
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
            }
            catch
            {
                this.Correct = false;
            }
        }
    }
}
