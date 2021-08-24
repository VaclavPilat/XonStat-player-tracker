
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.refreshList = new System.Windows.Forms.Button();
            this.addPlayer = new System.Windows.Forms.Button();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.players = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.info = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.players)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshList
            // 
            this.refreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshList.BackColor = System.Drawing.Color.Khaki;
            this.refreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshList.Location = new System.Drawing.Point(904, 10);
            this.refreshList.Name = "refreshList";
            this.refreshList.Size = new System.Drawing.Size(150, 29);
            this.refreshList.TabIndex = 3;
            this.refreshList.Text = "Refresh list";
            this.refreshList.UseVisualStyleBackColor = false;
            this.refreshList.Click += new System.EventHandler(this.refreshList_Click);
            // 
            // addPlayer
            // 
            this.addPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPlayer.BackColor = System.Drawing.Color.PaleGreen;
            this.addPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlayer.Location = new System.Drawing.Point(1060, 10);
            this.addPlayer.Name = "addPlayer";
            this.addPlayer.Size = new System.Drawing.Size(160, 29);
            this.addPlayer.TabIndex = 2;
            this.addPlayer.Text = "Add new player";
            this.addPlayer.UseVisualStyleBackColor = false;
            this.addPlayer.Click += new System.EventHandler(this.addPlayer_Click);
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Location = new System.Drawing.Point(12, 12);
            this.searchBar.Name = "searchBar";
            this.searchBar.PlaceholderText = "Search by player ID, nickname or name";
            this.searchBar.Size = new System.Drawing.Size(886, 27);
            this.searchBar.TabIndex = 1;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // players
            // 
            this.players.AllowUserToAddRows = false;
            this.players.AllowUserToDeleteRows = false;
            this.players.AllowUserToOrderColumns = true;
            this.players.AllowUserToResizeRows = false;
            this.players.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.players.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.players.BackgroundColor = System.Drawing.SystemColors.Window;
            this.players.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.players.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nickname,
            this.name,
            this.active,
            this.profile,
            this.info,
            this.delete});
            this.players.Location = new System.Drawing.Point(12, 47);
            this.players.Name = "players";
            this.players.ReadOnly = true;
            this.players.RowHeadersWidth = 51;
            this.players.RowTemplate.Height = 29;
            this.players.Size = new System.Drawing.Size(1208, 475);
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
            this.nickname.MinimumWidth = 180;
            this.nickname.Name = "nickname";
            this.nickname.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 300F;
            this.name.HeaderText = "Current player name";
            this.name.MinimumWidth = 250;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // active
            // 
            this.active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.active.HeaderText = "Last active";
            this.active.MinimumWidth = 130;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            // 
            // profile
            // 
            this.profile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.profile.DefaultCellStyle = dataGridViewCellStyle1;
            this.profile.FillWeight = 120F;
            this.profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profile.HeaderText = "Profile";
            this.profile.MinimumWidth = 150;
            this.profile.Name = "profile";
            this.profile.ReadOnly = true;
            this.profile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.profile.Text = "Show profile";
            this.profile.ToolTipText = "Show player profile in a browser";
            this.profile.UseColumnTextForButtonValue = true;
            this.profile.Width = 150;
            // 
            // info
            // 
            this.info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            this.info.DefaultCellStyle = dataGridViewCellStyle2;
            this.info.FillWeight = 120F;
            this.info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info.HeaderText = "Player info";
            this.info.MinimumWidth = 150;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.info.Text = "More information";
            this.info.ToolTipText = "Show more information bout this player";
            this.info.UseColumnTextForButtonValue = true;
            this.info.Width = 150;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSalmon;
            this.delete.DefaultCellStyle = dataGridViewCellStyle3;
            this.delete.FillWeight = 120F;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.HeaderText = "Delete player";
            this.delete.MinimumWidth = 150;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delete.Text = "Delete this player";
            this.delete.ToolTipText = "Delete this player";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 150;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 553);
            this.Controls.Add(this.players);
            this.Controls.Add(this.refreshList);
            this.Controls.Add(this.addPlayer);
            this.Controls.Add(this.searchBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XonStat player tracker - Overview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overview_FormClosing);
            this.Load += new System.EventHandler(this.Overview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.players)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshList;
        private System.Windows.Forms.Button addPlayer;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.DataGridView players;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.DataGridViewButtonColumn profile;
        private System.Windows.Forms.DataGridViewButtonColumn info;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}

