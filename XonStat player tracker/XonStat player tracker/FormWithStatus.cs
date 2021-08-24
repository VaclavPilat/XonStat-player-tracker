using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace XonStat_player_tracker
{
    public partial class FormWithStatus : Form
    {
        //################################################################################
        //###############################  TASKS & TOKENS  ###############################
        //################################################################################

        // Worker thread
        public Task task;

        // Cancellation token source for cancelling tasks
        protected CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected CancellationToken token;

        // Waiting time between steps (in ms)
        protected int WaitTime = 250;

        // Waits for a specified mount of time while checking if token has been canceled
        public void WaitForSeconds (float seconds)
        {
            for(int i = 0; i < (seconds * 1000f) / WaitTime; i++)
            {
                this.token.ThrowIfCancellationRequested();
                Thread.Sleep(WaitTime);
            }
        }

        //################################################################################
        //###################################  STATUS  ###################################
        //################################################################################

        // Status label
        protected Label status;

        // Method for initializing status label
        public void InitializeStatus (Label statusLabel = null)
        {
            if(statusLabel != null)
                this.status = statusLabel;
        }

        // If changing status is allowed
        protected bool Status_ChangingAllowed = true;

        // Variable for holding status message
        protected string Status_Message = null;

        // Changing form status message
        public void Status_ChangeMessage (string message)
        {
            if (this.Status_ChangingAllowed && this.status != null)
            {
                this.Status_Message = message;
                this.status.Text = this.Status_Message;
                Status_ChangeColor(Color.Khaki);
            }
        }

        // Changing status message (with final results)
        public void Status_ResultMessage (string message, int correct, int maximum)
        {
            if (this.Status_ChangingAllowed && this.status != null)
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
            if (this.Status_ChangingAllowed && this.status != null)
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
            if (this.Status_ChangingAllowed && this.status != null)
                this.status.BackColor = color;
        }

        // Changing form status progress
        public void Status_ChangeProgress (int current, int maximum)
        {
            if (this.Status_ChangingAllowed && this.status != null)
            {
                this.status.Text = this.Status_Message + " (" + current.ToString() + " out of " + maximum.ToString() + ")";
                Status_ChangeColor(Color.Khaki);
            }
        }
        public void Status_ChangeProgress (int current, int correct, int maximum)
        {
            if (this.Status_ChangingAllowed && this.status != null)
            {
                this.status.Text = this.Status_Message + " (" + current.ToString() + " out of " + maximum.ToString() + " done, " + correct.ToString() + " successful)";
                Status_ChangeColor(Color.Khaki);
            }
        }

        // Status that announces form closing
        public void Status_ClosingMessage ()
        {
            if (this.Status_ChangingAllowed && this.status != null)
            {
                this.status.Text = "Waiting for background tasks to finish...";
                Status_ChangeColor(Color.LightSkyBlue);
                this.Status_ChangingAllowed = false;
            }
        }
    }
}
