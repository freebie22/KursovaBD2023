namespace Pid_Kursach
{
    partial class Register
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Perehid = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Perehid);
            this.panel1.Controls.Add(this.ButtonLogin);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 450);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(200, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 48);
            this.label1.TabIndex = 11;
            this.label1.Text = "MyFirstCar";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(196, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 33);
            this.textBox1.TabIndex = 10;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Perehid
            // 
            this.Perehid.AutoSize = true;
            this.Perehid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Perehid.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Perehid.ForeColor = System.Drawing.SystemColors.Control;
            this.Perehid.Location = new System.Drawing.Point(204, 370);
            this.Perehid.Name = "Perehid";
            this.Perehid.Size = new System.Drawing.Size(189, 29);
            this.Perehid.TabIndex = 9;
            this.Perehid.Text = "Авторизуватися";
            this.Perehid.Click += new System.EventHandler(this.Perehid_Click);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.LightGreen;
            this.ButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(127)))), ((int)(((byte)(124)))));
            this.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(172)))), ((int)(((byte)(168)))));
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonLogin.Location = new System.Drawing.Point(208, 296);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(185, 51);
            this.ButtonLogin.TabIndex = 5;
            this.ButtonLogin.Text = "Реєстрація";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.Location = new System.Drawing.Point(196, 172);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(214, 33);
            this.password.TabIndex = 4;
            this.password.Enter += new System.EventHandler(this.password_Enter);
            this.password.Leave += new System.EventHandler(this.password_Leave);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.Location = new System.Drawing.Point(196, 96);
            this.login.Multiline = true;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(214, 51);
            this.login.TabIndex = 3;
            this.login.Enter += new System.EventHandler(this.login_Enter);
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.ShowIcon = false;
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Perehid;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}