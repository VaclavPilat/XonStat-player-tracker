﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace XonStat_player_tracker
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
            // Filling DatGridView with data
            players.Rows.Add(new string[] { "137012", "napalm", "<nade type=\"napalm\" />", "2 days ago" });
        }

        private void players_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (players.Columns[e.ColumnIndex].Name)
            {
                case "profile":
                    // Showing player profile in a browser
                    Process.Start(new ProcessStartInfo("http://stats.xonotic.org/player/" + players.Rows[e.RowIndex].Cells[0].Value.ToString())
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
