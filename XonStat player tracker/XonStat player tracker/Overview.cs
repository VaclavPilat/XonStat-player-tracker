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
using System.IO;
using System.Text.Json;

namespace XonStat_player_tracker
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            // Filling DatGridView with data
            players.Rows.Add(new string[] { "137012", "napalm", "<nade type=\"napalm\" />", "2 days ago" });
        }

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
