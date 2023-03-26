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
    public partial class CarModels : Form
    {
        DataBase dB = new DataBase();
        int selectedRow;

        public CarModels()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedItem = null;
            textBox3.Visible= false;
        }

        private void CarModels_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_types' table. You can move, or remove it, as needed.
            this.car_typesTableAdapter.Fill(this.myFirstCarDataSet.car_types);
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_names' table. You can move, or remove it, as needed.
            this.car_namesTableAdapter.Fill(this.myFirstCarDataSet.car_names);
            dB.OpenConnection();
            SqlDataAdapter data_ = new SqlDataAdapter("SELECT car_models.MoId AS 'Ідентифікатор моделі', car_models.MoName AS 'Назва  моделі', car_names.NName AS 'Назва відповідної марки' FROM car_models JOIN car_names ON car_models.NKod = car_names.NKod", dB.GetConnection());
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
                string selectedValue1 = row.Cells[2].Value.ToString();
                carnamesBindingSource.Position = carnamesBindingSource.Find("NName", selectedValue1);
                comboBox1.SelectedItem = selectedValue1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            var addQuery = $"insert into car_models (MoName, NKod) values ('{textBox2.Text}','{int.Parse(textBox3.Text)}')";

                var command = new SqlCommand(addQuery, dB.GetConnection());

                if(command.ExecuteNonQuery() == 1)
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(comboBox1.SelectedValue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.car_namesTableAdapter.Fill(this.myFirstCarDataSet.car_names);
            dB.OpenConnection();
            SqlDataAdapter data_ = new SqlDataAdapter("SELECT car_models.MoId AS 'Ідентифікатор моделі', car_models.MoName AS 'Назва  моделі', car_names.NName AS 'Назва відповідної марки' FROM car_models JOIN car_names ON car_models.NKod = car_names.NKod", dB.GetConnection());
            DataSet db = new DataSet();
            data_.Fill(db);
            dataGridView1.DataSource = db.Tables[0];
            dB.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlCommand sql = new SqlCommand($"UPDATE car_models SET car_models.MoName = '{textBox2.Text}', car_models.NKod = '{comboBox1.SelectedValue}' WHERE car_models.MoId = {textBox1.Text}", dB.GetConnection());
            sql.ExecuteNonQuery();
            dB.CloseConnection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (MessageBox.Show($"Видалити модель {textBox2.Text}?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM car_models WHERE MoId= " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
            }
            dB.CloseConnection();
        }

    }
}
