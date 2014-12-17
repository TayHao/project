namespace ClientV1
{
    partial class CreateAccountForm
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
            this.tUserName = new System.Windows.Forms.TextBox();
            this.tUserPassword = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.tSurName = new System.Windows.Forms.TextBox();
            this.tMidName = new System.Windows.Forms.TextBox();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.rbInstructor = new System.Windows.Forms.RadioButton();
            this.bAccept = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tTestField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tUserName
            // 
            this.tUserName.Location = new System.Drawing.Point(87, 61);
            this.tUserName.Name = "tUserName";
            this.tUserName.Size = new System.Drawing.Size(100, 20);
            this.tUserName.TabIndex = 0;
            // 
            // tUserPassword
            // 
            this.tUserPassword.Location = new System.Drawing.Point(87, 99);
            this.tUserPassword.Name = "tUserPassword";
            this.tUserPassword.Size = new System.Drawing.Size(100, 20);
            this.tUserPassword.TabIndex = 1;
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(87, 143);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(100, 20);
            this.tName.TabIndex = 2;
            // 
            // tSurName
            // 
            this.tSurName.Location = new System.Drawing.Point(87, 192);
            this.tSurName.Name = "tSurName";
            this.tSurName.Size = new System.Drawing.Size(100, 20);
            this.tSurName.TabIndex = 3;
            // 
            // tMidName
            // 
            this.tMidName.Location = new System.Drawing.Point(87, 230);
            this.tMidName.Name = "tMidName";
            this.tMidName.Size = new System.Drawing.Size(100, 20);
            this.tMidName.TabIndex = 4;
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Location = new System.Drawing.Point(228, 63);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(65, 17);
            this.rbStudent.TabIndex = 5;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Студент";
            this.rbStudent.UseVisualStyleBackColor = true;
            // 
            // rbInstructor
            // 
            this.rbInstructor.AutoSize = true;
            this.rbInstructor.Location = new System.Drawing.Point(228, 99);
            this.rbInstructor.Name = "rbInstructor";
            this.rbInstructor.Size = new System.Drawing.Size(84, 17);
            this.rbInstructor.TabIndex = 6;
            this.rbInstructor.TabStop = true;
            this.rbInstructor.Text = "Инструктор";
            this.rbInstructor.UseVisualStyleBackColor = true;
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(228, 139);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 7;
            this.bAccept.Text = "Принять";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tTestField
            // 
            this.tTestField.Location = new System.Drawing.Point(379, 60);
            this.tTestField.Name = "tTestField";
            this.tTestField.Size = new System.Drawing.Size(100, 20);
            this.tTestField.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Фамилия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Отчество";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Капча";
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 389);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tTestField);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.rbInstructor);
            this.Controls.Add(this.rbStudent);
            this.Controls.Add(this.tMidName);
            this.Controls.Add(this.tSurName);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.tUserPassword);
            this.Controls.Add(this.tUserName);
            this.Name = "CreateAccountForm";
            this.Text = "CreateAccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tUserName;
        private System.Windows.Forms.TextBox tUserPassword;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tSurName;
        private System.Windows.Forms.TextBox tMidName;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.RadioButton rbInstructor;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tTestField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}