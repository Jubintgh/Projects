namespace WindowsFormsApp1
{
    partial class thank_you
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
            this.label1 = new System.Windows.Forms.Label();
            this.homepageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(207, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thank you for submission";
            // 
            // homepageButton
            // 
            this.homepageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.homepageButton.Location = new System.Drawing.Point(275, 346);
            this.homepageButton.Name = "homepageButton";
            this.homepageButton.Size = new System.Drawing.Size(274, 52);
            this.homepageButton.TabIndex = 1;
            this.homepageButton.Text = "Home Page";
            this.homepageButton.UseVisualStyleBackColor = true;
            // 
            // thank_you
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.homepageButton);
            this.Controls.Add(this.label1);
            this.Name = "thank_you";
            this.Text = "thank_you_page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button homepageButton;
    }
}