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
    public partial class NewRidForm : Form
    {
        DataBase db = new DataBase();
        public NewRidForm()
        {
            InitializeComponent();
        }

        private void Stertu_Click(object sender, EventArgs e)
        {
            textBox_Tip.Text = "";
            textBox_Nazva.Text = "";
            textBox_Kilkist.Text = "";
            textBox_Tsina.Text = "";
            richTextBox1_Dodat.Text = "-";
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            db.OpenConnection();

            var type = textBox_Tip.Text;
            var Nazva = textBox_Nazva.Text;
            int Kilkist;
            int Tsina;
            var Dodat = richTextBox1_Dodat.Text;

            if (int.TryParse(textBox_Kilkist.Text, out Kilkist) && int.TryParse(textBox_Tsina.Text, out Tsina))
            {
                var addQuery = $"insert into riduna (Tip_Rid, Nazva_Rid, Kilkist_Rid, Tsina_Rid, Dodat_Rid) values ('{type}','{Nazva}','{Kilkist}','{Tsina}','{Dodat}')";

                var command = new SqlCommand(addQuery, db.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запис успішно створено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox_Tip.Text == "" || textBox_Nazva.Text == "" || textBox_Kilkist.Text == "" || textBox_Tsina.Text == "" || richTextBox1_Dodat.Text == "")
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Поле Кількіть та ціна повинні мати числовий формат!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            db.CloseConnection();
        }
    }
}
