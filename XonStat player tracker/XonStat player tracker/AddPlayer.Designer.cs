
namespace XonStat_player_tracker
{
    partial class AddPlayer
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
            this.addPlayerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.id_label = new System.Windows.Forms.Label();
            this.nickname_label = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.addPlayerLayout.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPlayerLayout
            // 
            this.addPlayerLayout.ColumnCount = 2;
            this.addPlayerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.addPlayerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.addPlayerLayout.Controls.Add(this.id_label, 0, 0);
            this.addPlayerLayout.Controls.Add(this.nickname_label, 0, 1);
            this.addPlayerLayout.Controls.Add(this.nickname, 1, 1);
            this.addPlayerLayout.Controls.Add(this.id, 1, 0);
            this.addPlayerLayout.Controls.Add(this.addButton, 0, 2);
            this.addPlayerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPlayerLayout.Location = new System.Drawing.Point(0, 0);
            this.addPlayerLayout.Name = "addPlayerLayout";
            this.addPlayerLayout.RowCount = 3;
            this.addPlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.addPlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.addPlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.addPlayerLayout.Size = new System.Drawing.Size(360, 117);
            this.addPlayerLayout.TabIndex = 0;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_label.Location = new System.Drawing.Point(3, 0);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(156, 40);
            this.id_label.TabIndex = 0;
            this.id_label.Text = "Player ID";
            this.id_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nickname_label
            // 
            this.nickname_label.AutoSize = true;
            this.nickname_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nickname_label.Location = new System.Drawing.Point(3, 40);
            this.nickname_label.Name = "nickname_label";
            this.nickname_label.Size = new System.Drawing.Size(156, 40);
            this.nickname_label.TabIndex = 1;
            this.nickname_label.Text = "Player nickname";
            this.nickname_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nickname
            // 
            this.nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nickname.Location = new System.Drawing.Point(165, 46);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(192, 27);
            this.nickname.TabIndex = 4;
            // 
            // id
            // 
            this.id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.id.Location = new System.Drawing.Point(165, 6);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(192, 27);
            this.id.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.BackColor = System.Drawing.Color.LightGreen;
            this.addPlayerLayout.SetColumnSpan(this.addButton, 2);
            this.addButton.Location = new System.Drawing.Point(5, 85);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(350, 29);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add player";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.addPlayerLayout);
            this.contentPanel.Location = new System.Drawing.Point(13, 13);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(360, 117);
            this.contentPanel.TabIndex = 1;
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Location = new System.Drawing.Point(13, 136);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(360, 25);
            this.statusPanel.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(360, 25);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 173);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.contentPanel);
            this.MaximizeBox = false;
            this.Name = "AddPlayer";
            this.Text = "XonStat player tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPlayer_FormClosing);
            this.Load += new System.EventHandler(this.AddPlayer_Load);
            this.addPlayerLayout.ResumeLayout(false);
            this.addPlayerLayout.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel addPlayerLayout;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label nickname_label;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
    }
}