﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace XonStat_player_tracker
{
    public partial class FormWithStatus : Form
    {
        private System.Windows.Forms.Label status;
        public void InitializeStatus()
        {
            this.status = new System.Windows.Forms.Label();
            // 
            // status
            // 
            this.status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.status.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.status.Location = new System.Drawing.Point(0, 528);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1182, 25);
            this.status.TabIndex = 1;
            this.status.Text = "Status";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(this.status);
        }

        // Variable for holding status message
        private string StatusMessage = null;

        // Changing form status message
        public void ChangeStatus (string message)
        {
            this.StatusMessage = message;
            this.status.Text = this.StatusMessage;
            ChangeStatusColor(Color.Khaki);
        }

        // Changing status message (with final results)
        public void ChangeStatus (string message, int correct, int maximum)
        {
            this.StatusMessage = message + " (" + correct.ToString() + " successful out of " + maximum.ToString() + ")";
            this.status.Text = this.StatusMessage;
            if(correct == maximum)
                ChangeStatusColor(Color.LightGreen);
            else
                ChangeStatusColor(Color.LightSalmon);
        }

        // Changing status background color
        public void ChangeStatusColor(Color color)
        {
            this.status.BackColor = color;
        }

        // Changing form status progress
        public void ChangeStatusProgress (int current, int maximum)
        {
            this.status.Text = this.StatusMessage + " (" + current.ToString() + " out of " + maximum.ToString() + ")";
            ChangeStatusColor(Color.Khaki);
        }
        public void ChangeStatusProgress(int current, int correct, int maximum)
        {
            this.status.Text = this.StatusMessage + " (" + current.ToString() + " out of " + maximum.ToString() + " done, " + correct.ToString() + " successful)";
            ChangeStatusColor(Color.Khaki);
        }
    }
}
