namespace ClientV1
{
    partial class Form1
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
            this.btestSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btestSend
            // 
            this.btestSend.Location = new System.Drawing.Point(143, 180);
            this.btestSend.Name = "btestSend";
            this.btestSend.Size = new System.Drawing.Size(75, 23);
            this.btestSend.TabIndex = 0;
            this.btestSend.Text = "test send";
            this.btestSend.UseVisualStyleBackColor = true;
            this.btestSend.Click += new System.EventHandler(this.btestSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btestSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btestSend;
    }
}

