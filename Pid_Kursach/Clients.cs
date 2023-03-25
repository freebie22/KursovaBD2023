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
    public partial class Clients : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;

        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select CKod AS 'Ідентифікатор клієнта', CPrizv AS 'Прізвище клієнта', CIm AS 'Ім я клієнта', CBat AS 'По-батькові клієнта', CNomTel AS 'Номер телефону', CPasport AS 'Серія паспорту', IsProcessed AS 'Чи опрацьовано?' FROM clients", dB.GetConnection());
            DataSet data = new DataSet();
            dataAdapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
            dB.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

             if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();

                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Чи опрацьовано?"];
                bool isChecked = (bool)cell.Value;
                cell.Value = !isChecked;
                checkBox1.Checked = !isChecked;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            var addQuery = $"insert into clients (CPrizv, CIm, CBat, CNomTel, CPasport, IsProcessed) values ('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}', '{textBox6.Text}', '{checkBox1.Checked}')";

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

        private void button5_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select CKod AS 'Ідентифікатор клієнта', CPrizv AS 'Прізвище клієнта', CIm AS 'Ім я клієнта', CBat AS 'По-батькові клієнта', CNomTel AS 'Номер телефону', CPasport AS 'Серія паспорту', IsProcessed AS 'Чи опрацьовано?' FROM clients", dB.GetConnection());
            DataSet data = new DataSet();
            dataAdapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
            dB.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            checkBox1.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlCommand sql = new SqlCommand($"UPDATE clients SET CPrizv= '{textBox2.Text}', CIm = '{textBox3.Text}', CBat = '{textBox4.Text}', CNomTel = '{textBox5.Text}', CPasport = '{textBox6.Text}', IsProcessed = '{checkBox1.Checked}'  WHERE CKod = {textBox1.Text}", dB.GetConnection());

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
            if (MessageBox.Show($"Видалити даного клієнта?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM clients WHERE CKod= " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                checkBox1.Checked = false;
            }
            dB.CloseConnection();
        }
    }
}
