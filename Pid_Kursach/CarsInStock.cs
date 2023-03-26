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
    public partial class CarsInStock : Form
    {
        DataBase dB = new DataBase();
        public CarsInStock()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CarsInStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_types' table. You can move, or remove it, as needed.
            this.car_typesTableAdapter.Fill(this.myFirstCarDataSet.car_types);
            // TODO: This line of code loads data into the 'myFirstCarDataSet.car_names' table. You can move, or remove it, as needed.
            this.car_namesTableAdapter.Fill(this.myFirstCarDataSet.car_names);
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
        }

        
    }
}
