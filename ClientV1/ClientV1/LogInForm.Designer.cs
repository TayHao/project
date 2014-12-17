namespace ClientV1
{
    partial class LogInForm
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
            this.bLogin = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tLogin = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(30, 132);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 0;
            this.bLogin.Text = "ОК";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(178, 132);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 1;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(67, 209);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(164, 23);
            this.bCreate.TabIndex = 2;
            this.bCreate.Text = "Создание учетной записи";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // tLogin
            // 
            this.tLogin.Location = new System.Drawing.Point(178, 37);
            this.tLogin.Name = "tLogin";
            this.tLogin.Size = new System.Drawing.Size(100, 20);
            this.tLogin.TabIndex = 5;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(178, 86);
            this.tPassword.Name = "tPassword";
            this.tPassword.Size = new System.Drawing.Size(100, 20);
            this.tPassword.TabIndex = 6;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bLogin);
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tLogin;
        private System.Windows.Forms.TextBox tPassword;
    }
}