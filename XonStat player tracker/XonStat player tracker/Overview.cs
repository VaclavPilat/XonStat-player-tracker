using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    }
}
