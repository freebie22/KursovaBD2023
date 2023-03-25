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
    public partial class CarNames : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;

        public CarNames()
        {
            InitializeComponent();
            textBox3.Visible = false;
        }

        private void CarNames_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data_ = new SqlDataAdapter("SELECT NKod AS 'Ідентифікатор марки', NName AS 'Назва марки' FROM car_names;", dB.GetConnection());
            DataSet db = new DataSet();
            data_.Fill(db);
            dataGridView1.DataSource = db.Tables[0];
            dB.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            



        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dB.OpenConnection();
            var addQuery = $"insert into car_names (NName) values ('{textBox2.Text}')";

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlCommand sql = new SqlCommand($"UPDATE car_names SET car_names.NName = '{textBox2.Text}'  WHERE car_names.NKod = {textBox1.Text}", dB.GetConnection());
            sql.ExecuteNonQuery();
            dB.CloseConnection();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (MessageBox.Show($"Видалити модель {textBox2.Text}?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM car_names WHERE NKod= " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
            }
            dB.CloseConnection();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data_ = new SqlDataAdapter("SELECT NKod AS 'Ідентифікатор марки', NName AS 'Назва марки' FROM car_names;", dB.GetConnection());
            DataSet db = new DataSet();
            data_.Fill(db);
            dataGridView1.DataSource = db.Tables[0];
            dB.CloseConnection();
        }
    }
}
