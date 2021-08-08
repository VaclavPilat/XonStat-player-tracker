using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace XonStat_player_tracker
{
    public class Player
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }

        // Constructor with int ID
        public Player(int id) => this.ID = id;

        // Constructor with string ID
        public Player (string id)
        {
            int number = 0;
            if (!Int32.TryParse(id, out number))
                Overview.StartupErrors.Add("Cannot convert \"" + id + "\" to a player ID.");
            this.ID = number;
        }

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
            // Checking if there is a nickname that matches ID
            string nickname = "---";
            if(Array.IndexOf(ConfigurationManager.AppSettings.AllKeys, this.ID.ToString()) > -1)
                nickname = ConfigurationManager.AppSettings[this.ID.ToString()];
            else
                Overview.StartupErrors.Add("Cannot find player nickname using ID = " + this.ID.ToString());
            this.Nickname = nickname;
            return this.Nickname;
        }

        // Loads current player nickname and returns it
        public string LoadName()
        {
            return null;
        }
    }
}
