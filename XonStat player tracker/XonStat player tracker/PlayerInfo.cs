using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XonStat_player_tracker
{
    public partial class PlayerInfo : Form
    {
        // Player reference
        public Player Player;

        // Worker thread
        private Task task;

        // Cancellation token source for cancelling tasks
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public PlayerInfo() => InitializeComponent();

        public PlayerInfo(Player player)
        {
            this.Player = player;
            InitializeComponent();
        }

        // Starting worker thread
        private void PlayerInfo_Load(object sender, EventArgs e)
        {
            var token = tokenSource.Token;
            task = new Task(() => LoadPlayerInfo(token));
            task.Start();
        }

        // Showing errors after loading
        private void PlayerInfo_Shown(object sender, EventArgs e) => Overview.ShowErrors();

        // Loading player info
        private void LoadPlayerInfo(CancellationToken token)
        {
            try
            {
                this.Player.LoadAll();
                this.Invoke(new Action(() => { 
                    this.id.Text = this.Player.ID.ToString();
                    this.nickname.Text = this.Player.Nickname;
                    this.name.Text = this.Player.Name;
                    this.active.Text = this.Player.Active;
                    this.since.Text = this.Player.Since;
                }));
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception e)
            {
                Overview.Errors.Enqueue(e.Message);
            }
            this.Invoke(new Action(() => { Overview.ShowErrors(); }));
        }

        private void PlayerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            task.Wait();
            tokenSource.Dispose();
        }
    }
}
