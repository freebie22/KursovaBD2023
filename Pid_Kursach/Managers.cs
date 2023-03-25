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
    public partial class Managers : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;

        public Managers()
        {
            InitializeComponent();
        }

        private void Managers_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select MKod AS 'Ідентифікатор менеджера', MPrizv AS 'Прізвище менеджера', MIm AS 'Ім я менеджера', MBat AS 'По-батькові менеджера', MTel AS 'Номер телефону', MPay AS 'Оклад' FROM managers", dB.GetConnection());
            DataSet ds = new DataSet(); 
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            textBox5.Text = "";
            if(e.RowIndex >= 0) {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "+380";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            var addQuery = $"insert into managers (MPrizv, MIm, MBat, MTel, MPay) values ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')";

            var command = new SqlCommand(addQuery, dB.GetConnection());

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запис успішно створено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
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
            SqlCommand sql = new SqlCommand($"UPDATE managers SET MPrizv= '{textBox2.Text}', MIm = '{textBox3.Text}', MBat = '{textBox4.Text}', MTel = '{textBox5.Text}', MPay = '{textBox6.Text}'  WHERE MKod = {textBox1.Text}", dB.GetConnection());

            if (sql.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запис успішно оновлено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Запис не оновлено!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dB.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (MessageBox.Show($"Видалити даного менеджера?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM managers WHERE MKod= " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
            }
            dB.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select MKod AS 'Ідентифікатор менеджера', MPrizv AS 'Прізвище менеджера', MIm AS 'Ім я менеджера', MBat AS 'По-батькові менеджера', MTel AS 'Номер телефону', MPay AS 'Оклад' FROM managers", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }
    }
}
