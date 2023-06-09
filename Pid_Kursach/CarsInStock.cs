﻿using System;
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

namespace Pid_Kursach
{
    public partial class CarsInStock : Form
    {
        DataBase dB = new DataBase();
        private readonly checkUser _user;
        int selectedRow;
        public CarsInStock()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("montserrat", 12);
            dataGridView1.DefaultCellStyle.Font = new Font("montserrat", 12);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarsInStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_types' table. You can move, or remove it, as needed.
            this.car_typesTableAdapter.Fill(this.myFirstCarDataSet.car_types);
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_names' table. You can move, or remove it, as needed.
            this.car_namesTableAdapter.Fill(this.myFirstCarDataSet.car_names);
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter(
                "SELECT cars_in_stock.Car_Id AS 'ID'," +
                " car_names.NName AS 'Марка'," +
                " car_models.MoName AS 'Модель'," +
                " car_types.TNazvaType AS 'Тип кузову'," +
                " cars_in_stock.Car_Color AS 'Колір'," +
                " cars_in_stock.Car_Nomer AS 'Номер'," +
                " cars_in_stock.Car_Vin AS 'VIN'," +
                " cars_in_stock.Car_Price AS 'Ціна, $'," +
                " cars_in_stock.Car_Year AS 'Рік випуску'," +
                " cars_in_stock.Car_Engine AS 'Об єм двигуна, л'," +
                " cars_in_stock.Car_GearBox AS 'Коробка передач'," +
                " cars_in_stock.Car_Fuel AS 'Тип пального'," +
                " cars_in_stock.Car_Condition AS 'Стан автомобіля'," +
                " cars_in_stock.Car_Drive AS 'Привід'," +
                " cars_in_stock.Car_Mileage AS 'Пробіг, тис. км'," +
                " cars_in_stock.Car_Date_Prihod AS 'Дата надходження'," +
                " cars_in_stock.Car_Is_Avaliable AS 'Наявність'," +
                " cars_in_stock.Car_Is_Sold AS 'Чи продана?'" +
                "FROM cars_in_stock " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model = car_models.MoId " +
                "JOIN car_types ON cars_in_stock.Car_Type = car_types.TKodType Order By cars_in_stock.Car_Is_Avaliable;", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
            FillBrandComboBox();
        }

        private void FillBrandComboBox()
        {
            dB.OpenConnection();
            string query = "SELECT NKod, NName FROM car_names ORDER BY NName ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, dB.GetConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "NName";
                comboBox1.ValueMember = "NKod";
            dB.CloseConnection();
        }

        private void FillModelComboBox(int brandId)
        {
            dB.OpenConnection();
            string query = "SELECT MoId, MoName FROM car_models WHERE NKod = @NKod ORDER BY MoName ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, dB.GetConnection());
                adapter.SelectCommand.Parameters.AddWithValue("@NKod", brandId);
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBox2.DataSource = table;
                comboBox2.DisplayMember = "MoName";
                comboBox2.ValueMember = "MoId";
            dB.CloseConnection();
        }

     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedValue != null)
            {
                int selectedBrandId = (int)((DataRowView)comboBox1.SelectedItem)["NKod"];
                FillModelComboBox(selectedBrandId);
            }

            textBox5.Text = Convert.ToString(comboBox1.SelectedValue);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null;
            comboBox6.SelectedItem = null;
            comboBox7.SelectedItem = null;
            comboBox8.SelectedItem = null;
            comboBox9.SelectedItem = null;
            comboBox10.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Now;
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter(
                "SELECT cars_in_stock.Car_Id AS 'ID'," +
                " car_names.NName AS 'Марка'," +
                " car_models.MoName AS 'Модель'," +
                " car_types.TNazvaType AS 'Тип кузову'," +
                " cars_in_stock.Car_Color AS 'Колір'," +
                " cars_in_stock.Car_Nomer AS 'Номер'," +
                " cars_in_stock.Car_Vin AS 'VIN'," +
                " cars_in_stock.Car_Price AS 'Ціна, $'," +
                " cars_in_stock.Car_Year AS 'Рік випуску'," +
                " cars_in_stock.Car_Engine AS 'Об єм двигуна, л'," +
                " cars_in_stock.Car_GearBox AS 'Коробка передач'," +
                " cars_in_stock.Car_Fuel AS 'Тип пального'," +
                " cars_in_stock.Car_Condition AS 'Стан автомобіля'," +
                " cars_in_stock.Car_Drive AS 'Привід'," +
                " cars_in_stock.Car_Mileage AS 'Пробіг, тис. км'," +
                " cars_in_stock.Car_Date_Prihod AS 'Дата надходження'," +
                " cars_in_stock.Car_Is_Avaliable AS 'Наявність'," +
                " cars_in_stock.Car_Is_Sold AS 'Чи продана?'" +
                "FROM cars_in_stock " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model = car_models.MoId " +
                "JOIN car_types ON cars_in_stock.Car_Type = car_types.TKodType Order By cars_in_stock.Car_Is_Avaliable;", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1.Text = row.Cells[0].Value.ToString();
                string selectedValue1 = row.Cells[1].Value.ToString();
                int index = comboBox1.FindStringExact(selectedValue1);
                if (index >= 0)
                {
                    comboBox1.SelectedIndex = index;
                }

                string selectedValue2 = row.Cells[2].Value.ToString();

                int index2 = comboBox2.FindStringExact(selectedValue2);
                if (index2 >= 0)
                {
                    comboBox2.SelectedIndex = index2;
                }

                string selectedValue3 = row.Cells[3].Value.ToString();
                cartypesBindingSource.Position = cartypesBindingSource.Find("TNazvaType", selectedValue3);
                comboBox3.SelectedItem = selectedValue3;

                textBox2.Text = row.Cells[7].Value.ToString();

                string selectedValue4 = row.Cells[8].Value.ToString();

                int index4 = comboBox4.Items.IndexOf(selectedValue4);
                if (index4 >= 0)
                {
                    comboBox4.SelectedIndex = index4;
                }

                textBox3.Text = row.Cells[9].Value.ToString();

                string selectedValue5 = row.Cells[10].Value.ToString();

                int index5 = comboBox5.Items.IndexOf(selectedValue5);
                if(index5 >= 0)
                {
                    comboBox5.SelectedIndex = index5;
                }

                string selectedValue6 = row.Cells[11].Value.ToString();

                int index6 = comboBox6.Items.IndexOf(selectedValue6);
                if (index6 >= 0)
                {
                    comboBox6.SelectedIndex = index6;
                }

                string selectedValue7 = row.Cells[12].Value.ToString();

                int index7 = comboBox7.Items.IndexOf(selectedValue7);
                if (index7 >= 0)
                {
                    comboBox7.SelectedIndex = index7;
                }

                string selectedValue8 = row.Cells[13].Value.ToString();

                int index8 = comboBox8.Items.IndexOf(selectedValue8);
                if (index8 >= 0)
                {
                    comboBox8.SelectedIndex = index8;
                }

                textBox4.Text = row.Cells[14].Value.ToString();

                string selectedValue9 = row.Cells[15].Value.ToString();
                DateTime selectedDate;
                if (DateTime.TryParse(selectedValue9, out selectedDate))
                {
                    dateTimePicker1.Value = selectedDate;
                }

                if ((bool)row.Cells[16].Value)
                {
                    comboBox9.SelectedItem = "В наявності";
                }

                else
                {
                    comboBox9.SelectedItem = "Продане";
                }

                if ((bool)row.Cells[17].Value)
                {
                    comboBox10.SelectedItem = "Так";
                }

                else
                {
                    comboBox10.SelectedItem = "Ні";
                }

                textBox18.Text = row.Cells[5].Value.ToString();
                textBox19.Text = row.Cells[6].Value.ToString();
                textBox20.Text = row.Cells[4].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            DateTime date = DateTime.ParseExact(textBox14.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            SqlCommand command= new SqlCommand($"Insert into cars_in_stock (Car_Name," +
                $" Car_Model," +
                $" Car_Type," +
                $" Car_Color," +
                $" Car_Nomer," +
                $" Car_Vin," +
                $" Car_Price," +
                $" Car_Year," +
                $" Car_Engine," +
                $" Car_GearBox," +
                $" Car_Fuel," +
                $" Car_Condition," +
                $" Car_Drive," +
                $" Car_Mileage," +
                $" Car_Date_Prihod," +
                $" Car_Is_Avaliable," +
                $" Car_Is_Sold) " +
                $"Values ('{int.Parse(textBox5.Text)}', '{int.Parse(textBox6.Text)}', '{int.Parse(textBox7.Text)}', '{textBox20.Text}', '{textBox18.Text}', '{textBox19.Text}', '{textBox2.Text}', '{textBox8.Text}', '{double.Parse(textBox3.Text)}', '{textBox9.Text}', '{textBox10.Text}', '{textBox11.Text}', '{textBox12.Text}', '{textBox4.Text}', '{date:yyyy-MM-dd}', '{bool.Parse(textBox13.Text)}', '{bool.Parse(textBox15.Text)}')", dB.GetConnection());

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(comboBox2.SelectedValue);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = Convert.ToString(comboBox3.SelectedValue);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = Convert.ToString(comboBox4.SelectedItem);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = Convert.ToString(comboBox5.SelectedItem);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Text = Convert.ToString(comboBox6.SelectedItem);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = Convert.ToString(comboBox7.SelectedItem);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox12.Text = Convert.ToString(comboBox8.SelectedItem);
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox9.SelectedItem == "В наявності")
            {
                textBox13.Text = "true";
            }
            else
            {
                textBox13.Text = "false";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dateTimePicker1.Value;
            this.textBox14.Text = date.ToString("yyyy-MM-dd");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter(
                "SELECT cars_in_stock.Car_Id AS 'ID'," +
                " car_names.NName AS 'Марка'," +
                " car_models.MoName AS 'Модель'," +
                " car_types.TNazvaType AS 'Тип кузову'," +
                " cars_in_stock.Car_Color AS 'Колір'," +
                " cars_in_stock.Car_Nomer AS 'Номер'," +
                " cars_in_stock.Car_Vin AS 'VIN'," +
                " cars_in_stock.Car_Price AS 'Ціна, $'," +
                " cars_in_stock.Car_Year AS 'Рік випуску'," +
                " cars_in_stock.Car_Engine AS 'Об єм двигуна, л'," +
                " cars_in_stock.Car_GearBox AS 'Коробка передач'," +
                " cars_in_stock.Car_Fuel AS 'Тип пального'," +
                " cars_in_stock.Car_Condition AS 'Стан автомобіля'," +
                " cars_in_stock.Car_Drive AS 'Привід'," +
                " cars_in_stock.Car_Mileage AS 'Пробіг, тис. км'," +
                " cars_in_stock.Car_Date_Prihod AS 'Дата надходження'," +
                " cars_in_stock.Car_Is_Avaliable AS 'Наявність'," +
                " cars_in_stock.Car_Is_Sold AS 'Чи продана?'" +
                "FROM cars_in_stock " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model = car_models.MoId " +
                "JOIN car_types ON cars_in_stock.Car_Type = car_types.TKodType Order By cars_in_stock.Car_Is_Avaliable;", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (MessageBox.Show($"Видалити дане авто зі списку?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand dd = new SqlCommand("DELETE FROM cars_in_stock WHERE Car_Id = " + textBox1.Text, dB.GetConnection());
                MessageBox.Show("Видалено " + dd.ExecuteNonQuery() + " запис.");
            }
            dB.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            DateTime date = DateTime.ParseExact(textBox14.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            SqlCommand command = new SqlCommand($"UPDATE cars_in_stock SET Car_Name = '{int.Parse(textBox5.Text)}', Car_Model = '{int.Parse(textBox6.Text)}', Car_Type = '{int.Parse(textBox7.Text)}', Car_Color = '{textBox20.Text}', Car_Nomer = '{textBox18.Text}', Car_Vin = '{textBox19.Text}', Car_Price = '{textBox2.Text}', Car_Year = '{textBox8.Text}', Car_Engine = '{textBox3.Text}', Car_GearBox = '{textBox9.Text}', Car_Fuel = '{textBox10.Text}', Car_Condition = '{textBox11.Text}', Car_Drive = '{textBox12.Text}', Car_Mileage = '{textBox4.Text}', Car_Date_Prihod = '{date:yyyy-MM-dd}', Car_Is_Avaliable = '{bool.Parse(textBox13.Text)}', Car_Is_Sold = '{bool.Parse(textBox15.Text)}',  WHERE Car_Id = {textBox1.Text}", dB.GetConnection());

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запис успішно оновлено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запис не оновлено!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dB.CloseConnection();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.SelectedItem == "Так")
            {
                textBox15.Text = "true";
            }
            else
            {
                textBox15.Text = "false";
            }
        }

        private void NameSearch(DataGridView dgw)
        {

                 dB.OpenConnection();
            
                string query = "SELECT cars_in_stock.Car_Id AS 'ID'," +
                " car_names.NName AS 'Марка'," +
                " car_models.MoName AS 'Модель'," +
                " car_types.TNazvaType AS 'Тип кузову'," +
                " cars_in_stock.Car_Price AS 'Ціна, $'," +
                " cars_in_stock.Car_Year AS 'Рік випуску'," +
                " cars_in_stock.Car_Engine AS 'Об єм двигуна, л'," +
                " cars_in_stock.Car_GearBox AS 'Коробка передач'," +
                " cars_in_stock.Car_Fuel AS 'Тип пального'," +
                " cars_in_stock.Car_Condition AS 'Стан автомобіля'," +
                " cars_in_stock.Car_Drive AS 'Привід'," +
                " cars_in_stock.Car_Mileage AS 'Пробіг, тис. км'," +
                " cars_in_stock.Car_Date_Prihod AS 'Дата надходження'," +
                " cars_in_stock.Car_Is_Avaliable AS 'Наявність', " +
                " cars_in_stock.Car_Is_Sold AS 'Чи продана?'" +
                "FROM cars_in_stock " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model = car_models.MoId " +
                "JOIN car_types ON cars_in_stock.Car_Type = car_types.TKodType WHERE car_names.NName LIKE '%' + @searchTerm + '%' ;";

                // Підготовка параметрів для запиту
                SqlCommand command = new SqlCommand(query, dB.GetConnection());
           

            dgw.Rows.Clear();

            // Виконання запиту та обробка результатів
            try
                {
                    SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string carName = reader["car_names.NName"].ToString();
                    string carModel = reader["car_models.MoName"].ToString();
                    int carYear = (int)reader["cars_in_stock.Car_Year"];

                    // Додавання нового рядка до DataGridView
                    dgw.Rows.Add(carName, carModel, carYear);
                }
                }
            catch(Exception ex)
            {

            }
                
            dB.CloseConnection();

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            NameSearch(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dB.OpenConnection();
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Please select a date.");
                return;
            }

            dataGridView1.DataSource = null;

            dataGridView1.Rows.Clear();

            string query = "SELECT cars_in_stock.Car_Id AS 'ID'," +
                " car_names.NName AS 'Марка'," +
                " car_models.MoName AS 'Модель'," +
                " car_types.TNazvaType AS 'Тип кузову'," +
                " cars_in_stock.Car_Price AS 'Ціна, $'," +
                " cars_in_stock.Car_Year AS 'Рік випуску'," +
                " cars_in_stock.Car_Engine AS 'Об єм двигуна, л'," +
                " cars_in_stock.Car_GearBox AS 'Коробка передач'," +
                " cars_in_stock.Car_Fuel AS 'Тип пального'," +
                " cars_in_stock.Car_Condition AS 'Стан автомобіля'," +
                " cars_in_stock.Car_Drive AS 'Привід'," +
                " cars_in_stock.Car_Mileage AS 'Пробіг, тис. км'," +
                " cars_in_stock.Car_Date_Prihod AS 'Дата надходження'," +
                " cars_in_stock.Car_Is_Avaliable AS 'Наявність', " +
                " cars_in_stock.Car_Is_Sold AS 'Чи продана?'" +
                "FROM cars_in_stock " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model = car_models.MoId " +
                "JOIN car_types ON cars_in_stock.Car_Type = car_types.TKodType WHERE Car_Date_Prihod = @date";

            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@date", dateTimePicker2.Value.Date);

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            dB.CloseConnection();
        }
    }
}
