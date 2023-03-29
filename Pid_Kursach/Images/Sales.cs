using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pid_Kursach.Images
{
    public partial class Sales : Form
    {
        DataBase dB = new DataBase();

        int selectedRow;

        public Sales()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("montserrat", 12);
            dataGridView1.DefaultCellStyle.Font = new Font("montserrat", 12);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            richTextBox1.ReadOnly = true;
            DateTime date = DateTime.Now;
            this.textBox6.Text = date.ToString("yyyy-MM-dd");
            label9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            label9.Text = "";
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select sales.Sale_id AS 'Ідентифікатор документу', sales.Car_Id AS 'Код авто', sales.CKod AS 'Код клієнта', sales.MKod AS 'Код менеджера', sales.Sale_Price AS 'Фінальна ціна', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();

                label9.Text = $"Детальна інформація про акт: {textBox1.Text}";

                SqlDataAdapter data = new SqlDataAdapter("Select sales.Sale_id AS 'Ідентифікатор документу', cars_in_stock.Car_Id AS 'Ідентифікатор автомобіля', car_names.NName AS 'Марка авто', car_models.MoName AS 'Модель авто',  cars_in_stock.Car_Color AS 'Колір автомобіля', cars_in_stock.Car_Nomer AS 'Номер автомобіля', cars_in_stock.Car_Vin AS 'VIN', managers.MPrizv AS 'Прізвище менеджера', managers.MIm AS 'Ім я менеджера', managers.MBat AS 'По-батькові менеджера', clients.CPrizv AS 'Прізвище клієнта', clients.CIm AS 'Ім я клієнта', clients.CBat AS 'По-батькові клієнта', clients.CPasport AS 'Серія паспорта', sales.Sale_Price AS 'Фінальна сума, $', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales " +
                 "JOIN cars_in_stock ON sales.Car_Id = cars_in_stock.Car_Id " +
                 "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                 "JOIN car_models ON cars_in_stock.Car_Model= car_models.MoId " +
                 "JOIN managers ON sales.MKod= managers.MKod " +
                 $"JOIN clients ON sales.CKod = clients.CKod Where sales.Sale_id = '{textBox1.Text}' ", dB.GetConnection());


                DataSet dataSet = new DataSet();

                data.Fill(dataSet);


                DataTable dataTable = dataSet.Tables[0];

                StringBuilder stringBuilder = new StringBuilder();
                foreach (DataColumn column in dataTable.Columns)
                {
                    stringBuilder.AppendLine(column.ColumnName + ": " + dataTable.Rows[0][column.ColumnName].ToString());
                }

                // Очищаємо RichTextBox і відображаємо дані
                richTextBox1.Clear();
                richTextBox1.Text = stringBuilder.ToString();

                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();

            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            DateTime date = DateTime.ParseExact(textBox6.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var addQuery = $"insert into sales (Sale_id, Car_Id, CKod, MKod, Sale_Price, Sale_Date) values ('{Guid.NewGuid()}','{int.Parse(textBox2.Text)}','{int.Parse(textBox3.Text)}','{int.Parse(textBox4.Text)}','{int.Parse(textBox5.Text)}', '{date:yyyy-MM-dd}')";

            var command = new SqlCommand(addQuery, dB.GetConnection());

            command.ExecuteNonQuery();
      
                MessageBox.Show("Запис успішно створено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dB.CloseConnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Please select a date.");
                return;
            }

            // Очистити DataGridView перед запитом
            var dataSource = dataGridView1.DataSource;

            // Встановлення джерела даних на null
            dataGridView1.DataSource = null;

            // Очистити рядки
            dataGridView1.Rows.Clear();


            string query = "Select sales.Sale_id AS 'Ідентифікатор документу', sales.Car_Id AS 'Код авто', sales.CKod AS 'Код клієнта', sales.MKod AS 'Код менеджера', sales.Sale_Price AS 'Фінальна ціна', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales WHERE Sale_Date = @date";

            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            dB.CloseConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select sales.Sale_id AS 'Ідентифікатор документу', sales.Car_Id AS 'Код авто', sales.CKod AS 'Код клієнта', sales.MKod AS 'Код менеджера', sales.Sale_Price AS 'Фінальна ціна', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }
    }
}
