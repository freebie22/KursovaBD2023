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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Pid_Kursach
{
    public partial class Users : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;


        public Users()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

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
                textBox5.Text = row.Cells[4].Value.ToString();

                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Чи є адміном?"];
                bool isChecked = (bool)cell.Value;
                cell.Value = !isChecked;
                checkBox2.Checked = !isChecked;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            string addQuery;

            addQuery = $"insert into users (login, pass, confirm_pass, Kod) values ('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}','{checkBox2.Checked}')";

            var command = new SqlCommand(addQuery, dB.GetConnection());


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Користувача додано!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запис не створено!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dB.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlCommand sql;

            sql = new SqlCommand($"UPDATE Users SET users.login = '{textBox2.Text}', users.pass = '{textBox3.Text}', users.confirm_pass = '{textBox4.Text}', users.Kod = '{checkBox2.Checked}'  WHERE users.Id = '{textBox1.Text}'", dB.GetConnection());

            if (sql.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запис успішно оновлено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запис не оновлено!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dB.CloseConnection();
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           

        }
    }
}
