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
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select sales.Sale_id AS 'Ідентифікатор документу', car_names.NName AS 'Марка авто', car_models.MoName AS 'Модель авто', cars_in_stock.Car_Id AS 'Ідентифікатор автомобіля', managers.MPrizv AS 'Прізвище менеджера', managers.MIm AS 'Ім я менеджера', managers.MBat AS 'По-батькові менеджера', clients.CPrizv AS 'Прізвище клієнта', clients.CIm AS 'Ім я клієнта', clients.CBat AS 'По-батькові клієнта', clients.CPasport AS 'Серія паспорта', sales.Sale_Price AS 'Фінальна сума, $', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales " +
                "JOIN cars_in_stock ON sales.Car_Id = cars_in_stock.Car_Id " +
                "JOIN car_names ON cars_in_stock.Car_Name = car_names.NKod " +
                "JOIN car_models ON cars_in_stock.Car_Model= car_models.MoId " +
                "JOIN managers ON sales.MKod= managers.MKod " +
                "JOIN clients ON sales.CKod = clients.CKod", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }


    
    }
}
