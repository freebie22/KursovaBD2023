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
    public partial class CarTypes : Form
    {
        DataBase dB = new DataBase();

        int selectedRow;

        public CarTypes()
        {
            InitializeComponent();
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            var addQuery = $"insert into car_types (TNazvaType) values ('{textBox2.Text}')";

            var command = new SqlCommand(addQuery, dB.GetConnection());

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запис успішно створено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlCommand sql = new SqlCommand($"UPDATE car_types SET car_types.TNazvaType = '{textBox2.Text}'  WHERE car_types.TKodType = '{textBox1.Text}'", dB.GetConnection());
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
            dB.OpenConnection();
            if (MessageBox.Show($"Видалити кузов типу {textBox2.Text}?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM car_types WHERE TKodType = " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            dB.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select car_types.TKodType AS 'Ідентифікатор кузова', car_types.TNazvaType As 'Назва кузова' FROM car_types", dB.GetConnection());
            DataSet data = new DataSet();
            dataAdapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
            dB.CloseConnection();
        }

        private void CarTypes_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select car_types.TKodType AS 'Ідентифікатор кузова', car_types.TNazvaType As 'Назва кузова' FROM car_types", dB.GetConnection());
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
            }
        }
    }
}
