using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace XonStat_player_tracker
{
    public partial class Overview : Form
    {
        // List of players
        public static List<Player> PlayerList = new List<Player>();

        // List of startup errors
        public static List<string> StartupErrors = new List<string>();

        public Overview() => InitializeComponent();

        private void Overview_Load(object sender, EventArgs e)
        {
            // Filling DatGridView with player data
            var playerList = ConfigurationManager.AppSettings;
            foreach (string id in playerList.AllKeys)
            {
                Player player = new Player(id);
                players.Rows.Add(new object[] { player.ID, player.LoadNickname() });
                PlayerList.Add(player);
            }
        }

        // Runs after _Load()
        private void Overview_Shown(object sender, EventArgs e)
        {
            // Showing startup errors
            string errorMessage = "";
            if (StartupErrors.Count > 0)
                for(int i = 0; i < StartupErrors.Count; i++)
                    errorMessage += "\n" + (i + 1).ToString() + ") " + StartupErrors[i];
            if (errorMessage != "")
                MessageBox.Show("These errors were found while loading this form:" + errorMessage, "XonStat player tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Actions after clicking on a cell value
        private void players_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Disabling onclick actions for column headers
                switch (players.Columns[e.ColumnIndex].Name)
                {
                    case "profile":
                        // Showing player profile in a browser
                        Process.Start(new ProcessStartInfo("https://stats.xonotic.org/player/" + players.Rows[e.RowIndex].Cells[0].Value.ToString())
                        { // https://stackoverflow.com/a/53245993
                            UseShellExecute = true,
                            Verb = "open"
                        });
                        break;
                    default:
                        break;
                }
        }
    }
}
