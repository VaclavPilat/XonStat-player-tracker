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
                MessageBox.Show("Cannot convert \"" + id + "\" to a player ID.", "XonStat player tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.ID = number;
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
            string nickname = ConfigurationManager.AppSettings[this.ID.ToString()];
            //MessageBox.Show("Cannot find player nickname using ID = " + this.ID.ToString(), "XonStat player tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
