using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace XonStat_player_tracker
{
    public partial class FormWithStatus : Form
    {
        // Cancellation token source for cancelling tasks
        protected CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected CancellationToken token;

        // Waiting time between steps (in ms)
        public int WaitTime = 250;

        // Waits for a specified mount of time while checking if token has been canceled
        public void WaitForSeconds (float seconds)
        {
            for(int i = 0; i < (seconds * 1000f) / WaitTime; i++)
            {
                this.token.ThrowIfCancellationRequested();
                Thread.Sleep(WaitTime);
            }
        }

        // Status label
        private System.Windows.Forms.Label status;

        // Method for initializing status label
        public void InitializeStatus()
        {
            this.status = new System.Windows.Forms.Label();
            this.status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.status.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.status.Location = new System.Drawing.Point(0, 528);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1182, 25);
            this.status.TabIndex = 1;
            this.status.Text = "---";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(this.status);
        }

        // If changing status is allowed
        protected bool Status_ChangingAllowed = true;

        // Variable for holding status message
        protected string Status_Message = null;

        // Changing form status message
        public void Status_ChangeMessage (string message)
        {
            if (this.Status_ChangingAllowed)
            {
                this.Status_Message = message;
                this.status.Text = this.Status_Message;
                Status_ChangeColor(Color.Khaki);
            }
        }

        // Changing status message (with final results)
        public void Status_ResultMessage (string message, int correct, int maximum)
        {
            if (this.Status_ChangingAllowed)
            {
                this.Status_Message = message + " (" + correct.ToString() + " successful out of " + maximum.ToString() + ")";
                this.status.Text = this.Status_Message;
                if (correct == maximum)
                    Status_ChangeColor(Color.LightGreen);
                else
                    Status_ChangeColor(Color.LightSalmon);
            }
        }

        public void Status_ResultMessage (string message, bool correct)
        {
            if (this.Status_ChangingAllowed)
            {
                this.Status_Message = message;
                this.status.Text = this.Status_Message;
                if (correct)
                    Status_ChangeColor(Color.LightGreen);
                else
                    Status_ChangeColor(Color.LightSalmon);
            }
        }

        // Changing status background color
        protected void Status_ChangeColor(Color color)
        {
            if (this.Status_ChangingAllowed)
                this.status.BackColor = color;
        }

        // Changing form status progress
        public void Status_ChangeProgress (int current, int maximum)
        {
            if (this.Status_ChangingAllowed)
            {
                this.status.Text = this.Status_Message + " (" + current.ToString() + " out of " + maximum.ToString() + ")";
                Status_ChangeColor(Color.Khaki);
            }
        }
        public void Status_ChangeProgress (int current, int correct, int maximum)
        {
            if (this.Status_ChangingAllowed)
            {
                this.status.Text = this.Status_Message + " (" + current.ToString() + " out of " + maximum.ToString() + " done, " + correct.ToString() + " successful)";
                Status_ChangeColor(Color.Khaki);
            }
        }

        // Status that announces form closing
        public void Status_ClosingMessage ()
        {
            this.status.Text = "Waiting for background tasks to finish...";
            Status_ChangeColor(Color.LightSkyBlue);
            this.Status_ChangingAllowed = false;
        }
    }
}
