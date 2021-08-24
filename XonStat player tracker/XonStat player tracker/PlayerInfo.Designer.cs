
namespace XonStat_player_tracker
{
    partial class PlayerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInfo));
            this.playerinfoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.id_label = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.Label();
            this.since_label = new System.Windows.Forms.Label();
            this.since = new System.Windows.Forms.Label();
            this.active_label = new System.Windows.Forms.Label();
            this.active = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.names_label = new System.Windows.Forms.Label();
            this.names = new System.Windows.Forms.TextBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.playerinfoLayout.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerinfoLayout
            // 
            this.playerinfoLayout.BackColor = System.Drawing.SystemColors.Control;
            this.playerinfoLayout.ColumnCount = 2;
            this.playerinfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerinfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerinfoLayout.Controls.Add(this.id_label, 0, 2);
            this.playerinfoLayout.Controls.Add(this.id, 1, 2);
            this.playerinfoLayout.Controls.Add(this.name, 0, 0);
            this.playerinfoLayout.Controls.Add(this.nickname, 0, 1);
            this.playerinfoLayout.Controls.Add(this.since_label, 0, 3);
            this.playerinfoLayout.Controls.Add(this.since, 1, 3);
            this.playerinfoLayout.Controls.Add(this.active_label, 0, 4);
            this.playerinfoLayout.Controls.Add(this.active, 1, 4);
            this.playerinfoLayout.Controls.Add(this.time_label, 0, 5);
            this.playerinfoLayout.Controls.Add(this.time, 1, 5);
            this.playerinfoLayout.Controls.Add(this.names_label, 0, 6);
            this.playerinfoLayout.Controls.Add(this.names, 1, 6);
            this.playerinfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerinfoLayout.Location = new System.Drawing.Point(0, 0);
            this.playerinfoLayout.Name = "playerinfoLayout";
            this.playerinfoLayout.RowCount = 7;
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerinfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.playerinfoLayout.Size = new System.Drawing.Size(457, 449);
            this.playerinfoLayout.TabIndex = 0;
            // 
            // id_label
            // 
            this.id_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_label.AutoSize = true;
            this.id_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.id_label.Location = new System.Drawing.Point(3, 90);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(222, 20);
            this.id_label.TabIndex = 6;
            this.id_label.Text = "Player ID";
            this.id_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // id
            // 
            this.id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.id.Location = new System.Drawing.Point(231, 90);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(223, 20);
            this.id.TabIndex = 8;
            this.id.Text = "---";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.AutoSize = true;
            this.playerinfoLayout.SetColumnSpan(this.name, 2);
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.name.Location = new System.Drawing.Point(3, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(451, 38);
            this.name.TabIndex = 0;
            this.name.Text = "---";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname
            // 
            this.nickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nickname.AutoSize = true;
            this.playerinfoLayout.SetColumnSpan(this.nickname, 2);
            this.nickname.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nickname.Location = new System.Drawing.Point(3, 40);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(451, 20);
            this.nickname.TabIndex = 9;
            this.nickname.Text = "---";
            this.nickname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // since_label
            // 
            this.since_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.since_label.AutoSize = true;
            this.since_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.since_label.Location = new System.Drawing.Point(3, 125);
            this.since_label.Name = "since_label";
            this.since_label.Size = new System.Drawing.Size(222, 20);
            this.since_label.TabIndex = 2;
            this.since_label.Text = "Playing since";
            this.since_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // since
            // 
            this.since.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.since.AutoSize = true;
            this.since.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.since.Location = new System.Drawing.Point(231, 125);
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(223, 20);
            this.since.TabIndex = 10;
            this.since.Text = "---";
            // 
            // active_label
            // 
            this.active_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.active_label.AutoSize = true;
            this.active_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.active_label.Location = new System.Drawing.Point(3, 160);
            this.active_label.Name = "active_label";
            this.active_label.Size = new System.Drawing.Size(222, 20);
            this.active_label.TabIndex = 3;
            this.active_label.Text = "Last active";
            this.active_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // active
            // 
            this.active.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.active.AutoSize = true;
            this.active.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.active.Location = new System.Drawing.Point(231, 160);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(223, 20);
            this.active.TabIndex = 11;
            this.active.Text = "---";
            // 
            // time_label
            // 
            this.time_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time_label.Location = new System.Drawing.Point(3, 195);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(222, 20);
            this.time_label.TabIndex = 4;
            this.time_label.Text = "Total time spent";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.time.Location = new System.Drawing.Point(231, 195);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(223, 20);
            this.time.TabIndex = 12;
            this.time.Text = "---";
            // 
            // names_label
            // 
            this.names_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.names_label.AutoSize = true;
            this.names_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.names_label.Location = new System.Drawing.Point(3, 230);
            this.names_label.Name = "names_label";
            this.names_label.Size = new System.Drawing.Size(222, 20);
            this.names_label.TabIndex = 7;
            this.names_label.Text = "Recently used names";
            this.names_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // names
            // 
            this.names.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.names.Dock = System.Windows.Forms.DockStyle.Fill;
            this.names.Location = new System.Drawing.Point(231, 233);
            this.names.Multiline = true;
            this.names.Name = "names";
            this.names.ReadOnly = true;
            this.names.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.names.Size = new System.Drawing.Size(223, 213);
            this.names.TabIndex = 13;
            this.names.TabStop = false;
            this.names.Text = "---";
            this.names.WordWrap = false;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.playerinfoLayout);
            this.contentPanel.Location = new System.Drawing.Point(13, 13);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(457, 449);
            this.contentPanel.TabIndex = 1;
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Location = new System.Drawing.Point(13, 468);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(457, 25);
            this.statusPanel.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(457, 25);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 503);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.contentPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerInfo";
            this.Text = "XonStat player tracker - Player info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerInfo_FormClosing);
            this.Load += new System.EventHandler(this.PlayerInfo_Load);
            this.playerinfoLayout.ResumeLayout(false);
            this.playerinfoLayout.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel playerinfoLayout;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label since_label;
        private System.Windows.Forms.Label active_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label names_label;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label active;
        private System.Windows.Forms.Label since;
        private System.Windows.Forms.Label nickname;
        private System.Windows.Forms.TextBox names;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
    }
}