namespace Pid_Kursach
{
    partial class Login
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.Perehod = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(217, 149);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 37);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.Location = new System.Drawing.Point(217, 207);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(214, 31);
            this.password.TabIndex = 4;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.LightGreen;
            this.ButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(127)))), ((int)(((byte)(124)))));
            this.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(172)))), ((int)(((byte)(168)))));
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonLogin.Location = new System.Drawing.Point(186, 281);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(170, 51);
            this.ButtonLogin.TabIndex = 5;
            this.ButtonLogin.Text = "Вхід";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // Perehod
            // 
            this.Perehod.AutoSize = true;
            this.Perehod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Perehod.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Perehod.ForeColor = System.Drawing.SystemColors.Control;
            this.Perehod.Location = new System.Drawing.Point(192, 345);
            this.Perehod.Name = "Perehod";
            this.Perehod.Size = new System.Drawing.Size(154, 33);
            this.Perehod.TabIndex = 6;
            this.Perehod.Text = "Реєстрація";
            this.Perehod.Click += new System.EventHandler(this.Perehod_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Perehod);
            this.panel1.Controls.Add(this.ButtonLogin);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 450);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(178, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 48);
            this.label1.TabIndex = 7;
            this.label1.Text = "MyFirstCar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(73, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 48);
            this.label2.TabIndex = 9;
            this.label2.Text = "Логін";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(54, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 48);
            this.label3.TabIndex = 10;
            this.label3.Text = "Пароль";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = global::Pid_Kursach.Properties.Resources._192_1925162_login_icon_png_trans;
            this.pictureBox1.Location = new System.Drawing.Point(434, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 105);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.ShowIcon = false;
            this.Text = "Вхід в програму";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Label Perehod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}