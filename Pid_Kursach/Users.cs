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
    public partial class Users : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;


        public Users()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = null;

        }

        private void Users_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("select users.id AS 'Ідентифікатор користувача', users.login AS 'Логін користувача', users.pass AS 'Пароль користувача', users.confirm_pass AS 'Підтверджений пароль', users.Kod AS 'Чи є адміном?' FROM users", dB.GetConnection());
            DataSet dt = new DataSet(); 
            data.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            dB.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0) 
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();

                if((bool)row.Cells[4].Value)
                {
                    comboBox1.SelectedItem = "Адміністратор";
                }

                else
                {
                    comboBox1.SelectedItem = "Користувач";
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("select users.id AS 'Ідентифікатор користувача', users.login AS 'Логін користувача', users.pass AS 'Пароль користувача', users.confirm_pass AS 'Підтверджений пароль', users.Kod AS 'Чи є адміном?' FROM users", dB.GetConnection());
            DataSet dt = new DataSet(); 
            data.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            dB.CloseConnection();
        }
    }
}
