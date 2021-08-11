
namespace XonStat_player_tracker
{
    partial class Overview
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.players = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profile = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.players)).BeginInit();
            this.SuspendLayout();
            // 
            // players
            // 
            this.players.AllowUserToAddRows = false;
            this.players.AllowUserToDeleteRows = false;
            this.players.AllowUserToOrderColumns = true;
            this.players.AllowUserToResizeRows = false;
            this.players.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.players.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nickname,
            this.name,
            this.active,
            this.profile});
            this.players.Dock = System.Windows.Forms.DockStyle.Fill;
            this.players.Location = new System.Drawing.Point(0, 0);
            this.players.Name = "players";
            this.players.ReadOnly = true;
            this.players.RowHeadersWidth = 51;
            this.players.RowTemplate.Height = 29;
            this.players.Size = new System.Drawing.Size(1182, 553);
            this.players.TabIndex = 0;
            this.players.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.players_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "Player ID";
            this.id.MinimumWidth = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nickname
            // 
            this.nickname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nickname.FillWeight = 200F;
            this.nickname.HeaderText = "Player nickname";
            this.nickname.MinimumWidth = 200;
            this.nickname.Name = "nickname";
            this.nickname.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 300F;
            this.name.HeaderText = "Current player name";
            this.name.MinimumWidth = 300;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // active
            // 
            this.active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.active.HeaderText = "Last active";
            this.active.MinimumWidth = 150;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            // 
            // profile
            // 
            this.profile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.profile.DefaultCellStyle = dataGridViewCellStyle1;
            this.profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profile.HeaderText = "Profile";
            this.profile.MinimumWidth = 150;
            this.profile.Name = "profile";
            this.profile.ReadOnly = true;
            this.profile.Text = "Show profile";
            this.profile.ToolTipText = "Show player profile in a browser";
            this.profile.UseColumnTextForButtonValue = true;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.players);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XonStat player tracker - Overview";
            this.Load += new System.EventHandler(this.Overview_Load);
            this.Shown += new System.EventHandler(this.Overview_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.players)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView players;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.DataGridViewButtonColumn profile;
    }
}

