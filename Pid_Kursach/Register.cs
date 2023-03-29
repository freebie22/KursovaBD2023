using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pid_Kursach
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 51);
            login.Text = "Логін...";
            password.Text = "Пароль...";
            textBox1.Text = "Підтвердження паролю...";

            login.ForeColor = Color.Gray;
            password.ForeColor = Color.Gray;
            textBox1.ForeColor= Color.Gray;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (login.Text == "Логін..." || login.Text == "" || password.Text == "Пароль..." || password.Text == "" || textBox1.Text == "Підтвердження паролю..." || textBox1.Text == "")
            {
                MessageBox.Show("Заповніть усі поля 0_о");
                return;
            }

            if (isUserExists())
                return;
            DataBase db = new DataBase();
            SqlCommand command = new SqlCommand("INSERT INTO users (login, pass, confirm_pass, Kod) VALUES (@login, @pass, @confirm_pass, 0)", db.GetConnection());

            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = Md5.Get_hash(password.Text);
            command.Parameters.Add("@confirm_pass", SqlDbType.VarChar).Value = Md5.Get_hash(textBox1.Text);

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Акаунт зареєстровано");
            }
            else
            {
                MessageBox.Show("Помилка:(");
            }

            db.CloseConnection();
        }

        public Boolean isUserExists()
        {
            DataBase db = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @login ", db.GetConnection());
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login.Text;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Даний логін існує, оберіть інший!)");
                return true;
            }

            else
                return false;
        }

        private void Perehid_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login register = new Login();
            register.Show();
        }

        private void closeButtoon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text == "Логін...")
            {
                login.Text = "";
            }
            login.ForeColor = Color.Black;
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                login.Text = "Логін...";
                login.ForeColor = Color.Gray;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Пароль...")
            {
                password.Text = "";
            }
            password.UseSystemPasswordChar = true;
            password.ForeColor = Color.Black;
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Пароль...";
                password.UseSystemPasswordChar = false;
                password.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Підтвердження паролю...")
            {
                textBox1.Text = "";
            }
            textBox1.UseSystemPasswordChar = true;
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Підтвердження паролю...";
                textBox1.UseSystemPasswordChar = false;
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
