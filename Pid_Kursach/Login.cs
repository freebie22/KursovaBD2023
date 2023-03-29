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

namespace Pid_Kursach
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 51);
            pictureBox1.BackColor = Color.Transparent;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void closeButtoon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = textBox1.Text;
            String passUser = Md5.Get_hash(password.Text);



            DataBase db = new DataBase();


            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @uL AND pass = @uP ", db.GetConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                var user = new checkUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[4]));

                this.Hide();
                MainMenu mainMenu = new MainMenu(user);
                mainMenu.Show();
            }

            else
            {
                MessageBox.Show("Невірний Логін або Пароль!");
            }
        }

        private void Perehod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
