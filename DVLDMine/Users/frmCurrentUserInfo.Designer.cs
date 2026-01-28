namespace DVLDMine
{
    partial class frmCurrentUserInfo
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlUserCardContrl1 = new DVLDMine.ctrlUserCardContrl();
            this.btnClsoe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDMine.Properties.Resources.close__2_;
            this.pictureBox2.Location = new System.Drawing.Point(795, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 158;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 157;
            this.label3.Text = "Current User Info";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(745, 449);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 156;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ctrlUserCardContrl1
            // 
            this.ctrlUserCardContrl1.Location = new System.Drawing.Point(10, 35);
            this.ctrlUserCardContrl1.Name = "ctrlUserCardContrl1";
            this.ctrlUserCardContrl1.Size = new System.Drawing.Size(829, 442);
            this.ctrlUserCardContrl1.TabIndex = 159;
            // 
            // btnClsoe
            // 
            this.btnClsoe.Location = new System.Drawing.Point(725, 471);
            this.btnClsoe.Name = "btnClsoe";
            this.btnClsoe.Size = new System.Drawing.Size(108, 33);
            this.btnClsoe.TabIndex = 160;
            this.btnClsoe.Text = "Close";
            this.btnClsoe.UseVisualStyleBackColor = true;
            this.btnClsoe.Click += new System.EventHandler(this.btnClsoe_Click);
            // 
            // frmCurrentUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 516);
            this.Controls.Add(this.btnClsoe);
            this.Controls.Add(this.ctrlUserCardContrl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCurrentUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCurrentUserInfo";
            this.Load += new System.EventHandler(this.frmCurrentUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private ctrlUserCardContrl ctrlUserCardContrl1;
        private System.Windows.Forms.Button btnClsoe;
    }
}