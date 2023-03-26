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
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            dB.OpenConnection();
            SqlDataAdapter data = new SqlDataAdapter("Select sales.Sale_id AS 'Ідентифікатор документу', cars_in_stock.Car_Name AS 'Марка авто', cars_in_stock.Car_Model AS 'Модель авто', cars_in_stock.Car_Id AS 'Ідентифікатор автомобіля', managers.MPrizv AS 'Прізвище менеджера', mamagers.MIm AS 'Ім я менеджера', sales.Sale_Price AS 'Фінальна сума', sales.Sale_Date AS 'Дата оформлення угоди' FROM sales ", dB.GetConnection());
            DataSet ds = new DataSet();
            data.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dB.CloseConnection();
        }
    }
}
