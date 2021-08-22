
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.id_label = new System.Windows.Forms.Label();
            this.nickname_label = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nickname = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.id_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nickname_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nickname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.id, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 154);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_label.Location = new System.Drawing.Point(3, 0);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(167, 40);
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
            this.nickname_label.Size = new System.Drawing.Size(167, 40);
            this.nickname_label.TabIndex = 1;
            this.nickname_label.Text = "Player nickname";
            this.nickname_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.LightSalmon;
            this.cancelButton.Location = new System.Drawing.Point(5, 85);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(163, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // nickname
            // 
            this.nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nickname.Location = new System.Drawing.Point(176, 46);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(206, 27);
            this.nickname.TabIndex = 4;
            // 
            // id
            // 
            this.id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.id.Location = new System.Drawing.Point(176, 6);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(206, 27);
            this.id.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.BackColor = System.Drawing.Color.LightGreen;
            this.addButton.Location = new System.Drawing.Point(178, 85);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(202, 29);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add player";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // AddPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 154);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "AddPlayer";
            this.Text = "XonStat player tracker";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label nickname_label;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button addButton;
    }
}