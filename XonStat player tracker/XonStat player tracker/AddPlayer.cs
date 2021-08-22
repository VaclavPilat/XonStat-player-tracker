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
    public partial class AddPlayer : FormWithStatus
    {
        public AddPlayer()
        {
            InitializeComponent();
            InitializeStatus();
        }

        // Closing form after clicking on Caancel button
        private void cancelButton_Click(object sender, EventArgs e) => this.Close();

        // Closing form
        private void AddPlayer_FormClosing(object sender, FormClosingEventArgs e) => Overview.AddPlayerWindow = null;

        // Validating inputs + adding new player
        private void addButton_Click(object sender, EventArgs e)
        {
            string id = this.id.Text;
            string nickname = this.nickname.Text;
            if (id != null && id.Length > 0 && nickname != null && nickname.Length > 0)
            {
                Status_ResultMessage("Text detected in both fields", true);
            }
            else
                Status_ResultMessage("Fields cannot be empty", false);
        }
    }
}
