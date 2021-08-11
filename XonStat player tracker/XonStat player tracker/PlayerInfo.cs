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
    public partial class PlayerInfo : Form
    {
        // Player reference
        public Player Player;

        public PlayerInfo() => InitializeComponent();

        public PlayerInfo(Player player)
        {
            this.Player = player;
            InitializeComponent();
        }

        private void PlayerInfo_Load(object sender, EventArgs e)
        {
            MessageBox.Show(this.Player.Name);
        }
    }
}
