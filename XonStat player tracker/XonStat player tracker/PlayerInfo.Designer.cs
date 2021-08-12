
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
            this.playerTable = new System.Windows.Forms.TableLayoutPanel();
            this.name = new System.Windows.Forms.Label();
            this.average_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.active_label = new System.Windows.Forms.Label();
            this.since_label = new System.Windows.Forms.Label();
            this.nickname_label = new System.Windows.Forms.Label();
            this.id_label = new System.Windows.Forms.Label();
            this.names_label = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.Label();
            this.since = new System.Windows.Forms.Label();
            this.active = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.average = new System.Windows.Forms.Label();
            this.names = new System.Windows.Forms.Label();
            this.playerTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerTable
            // 
            this.playerTable.BackColor = System.Drawing.SystemColors.Window;
            this.playerTable.ColumnCount = 2;
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerTable.Controls.Add(this.names, 1, 7);
            this.playerTable.Controls.Add(this.average, 1, 6);
            this.playerTable.Controls.Add(this.time, 1, 5);
            this.playerTable.Controls.Add(this.active, 1, 4);
            this.playerTable.Controls.Add(this.since, 1, 3);
            this.playerTable.Controls.Add(this.nickname, 1, 2);
            this.playerTable.Controls.Add(this.name, 0, 0);
            this.playerTable.Controls.Add(this.average_label, 0, 6);
            this.playerTable.Controls.Add(this.time_label, 0, 5);
            this.playerTable.Controls.Add(this.active_label, 0, 4);
            this.playerTable.Controls.Add(this.since_label, 0, 3);
            this.playerTable.Controls.Add(this.nickname_label, 0, 2);
            this.playerTable.Controls.Add(this.id_label, 0, 1);
            this.playerTable.Controls.Add(this.names_label, 0, 7);
            this.playerTable.Controls.Add(this.id, 1, 1);
            this.playerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTable.Location = new System.Drawing.Point(0, 0);
            this.playerTable.Name = "playerTable";
            this.playerTable.RowCount = 8;
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playerTable.Size = new System.Drawing.Size(505, 545);
            this.playerTable.TabIndex = 0;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name.AutoSize = true;
            this.playerTable.SetColumnSpan(this.name, 2);
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.name.Location = new System.Drawing.Point(3, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(499, 38);
            this.name.TabIndex = 0;
            this.name.Text = "Player name";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // average_label
            // 
            this.average_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.average_label.AutoSize = true;
            this.average_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.average_label.Location = new System.Drawing.Point(3, 245);
            this.average_label.Name = "average_label";
            this.average_label.Size = new System.Drawing.Size(246, 20);
            this.average_label.TabIndex = 5;
            this.average_label.Text = "Average playtime";
            this.average_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // time_label
            // 
            this.time_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time_label.Location = new System.Drawing.Point(3, 210);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(246, 20);
            this.time_label.TabIndex = 4;
            this.time_label.Text = "Total time spent";
            this.time_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // active_label
            // 
            this.active_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.active_label.AutoSize = true;
            this.active_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.active_label.Location = new System.Drawing.Point(3, 175);
            this.active_label.Name = "active_label";
            this.active_label.Size = new System.Drawing.Size(246, 20);
            this.active_label.TabIndex = 3;
            this.active_label.Text = "Last active";
            this.active_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // since_label
            // 
            this.since_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.since_label.AutoSize = true;
            this.since_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.since_label.Location = new System.Drawing.Point(3, 140);
            this.since_label.Name = "since_label";
            this.since_label.Size = new System.Drawing.Size(246, 20);
            this.since_label.TabIndex = 2;
            this.since_label.Text = "Playing since";
            this.since_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nickname_label
            // 
            this.nickname_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nickname_label.AutoSize = true;
            this.nickname_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nickname_label.Location = new System.Drawing.Point(3, 105);
            this.nickname_label.Name = "nickname_label";
            this.nickname_label.Size = new System.Drawing.Size(246, 20);
            this.nickname_label.TabIndex = 1;
            this.nickname_label.Text = "Player nickname";
            this.nickname_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // id_label
            // 
            this.id_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_label.AutoSize = true;
            this.id_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.id_label.Location = new System.Drawing.Point(3, 70);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(246, 20);
            this.id_label.TabIndex = 6;
            this.id_label.Text = "Player ID";
            this.id_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // names_label
            // 
            this.names_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.names_label.AutoSize = true;
            this.names_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.names_label.Location = new System.Drawing.Point(3, 280);
            this.names_label.Name = "names_label";
            this.names_label.Size = new System.Drawing.Size(246, 20);
            this.names_label.TabIndex = 7;
            this.names_label.Text = "Recently used names";
            this.names_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // id
            // 
            this.id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(255, 70);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(247, 20);
            this.id.TabIndex = 8;
            this.id.Text = "---";
            // 
            // nickname
            // 
            this.nickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nickname.AutoSize = true;
            this.nickname.Location = new System.Drawing.Point(255, 105);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(247, 20);
            this.nickname.TabIndex = 9;
            this.nickname.Text = "---";
            // 
            // since
            // 
            this.since.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.since.AutoSize = true;
            this.since.Location = new System.Drawing.Point(255, 140);
            this.since.Name = "since";
            this.since.Size = new System.Drawing.Size(247, 20);
            this.since.TabIndex = 10;
            this.since.Text = "---";
            // 
            // active
            // 
            this.active.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.active.AutoSize = true;
            this.active.Location = new System.Drawing.Point(255, 175);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(247, 20);
            this.active.TabIndex = 11;
            this.active.Text = "---";
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(255, 210);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(247, 20);
            this.time.TabIndex = 12;
            this.time.Text = "---";
            // 
            // average
            // 
            this.average.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.average.AutoSize = true;
            this.average.Location = new System.Drawing.Point(255, 245);
            this.average.Name = "average";
            this.average.Size = new System.Drawing.Size(247, 20);
            this.average.TabIndex = 13;
            this.average.Text = "---";
            // 
            // names
            // 
            this.names.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.names.AutoSize = true;
            this.names.Location = new System.Drawing.Point(255, 280);
            this.names.Name = "names";
            this.names.Size = new System.Drawing.Size(247, 20);
            this.names.TabIndex = 14;
            this.names.Text = "---";
            // 
            // PlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 545);
            this.Controls.Add(this.playerTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayerInfo";
            this.Text = "XonStat player tracker - Player info";
            this.Load += new System.EventHandler(this.PlayerInfo_Load);
            this.playerTable.ResumeLayout(false);
            this.playerTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel playerTable;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label nickname_label;
        private System.Windows.Forms.Label since_label;
        private System.Windows.Forms.Label active_label;
        private System.Windows.Forms.Label average_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label names_label;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label names;
        private System.Windows.Forms.Label average;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label active;
        private System.Windows.Forms.Label since;
        private System.Windows.Forms.Label nickname;
    }
}