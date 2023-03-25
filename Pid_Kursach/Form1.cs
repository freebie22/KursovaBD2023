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
    enum RoWState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        private readonly checkUser _user;

        DataBase db = new DataBase();

        int selectedRow;

        int k = 0;
        int ki = 0;

        public Form1(checkUser user)
        {
            _user = user;
            InitializeComponent();
        }

        private void IsAdmin()
        {
            Admining.Enabled = _user.IsAdmin;
            button_New.Enabled = _user.IsAdmin;
            button_Delit.Enabled = _user.IsAdmin;
            button_Zmin.Enabled = _user.IsAdmin;
            button_Save.Enabled = _user.IsAdmin;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_Det", "id");
            dataGridView1.Columns.Add("Tip_Det", "Тип");
            dataGridView1.Columns.Add("Nazva_Det", "Назва");
            dataGridView1.Columns.Add("Kilkist_Det", "Кількість");
            dataGridView1.Columns.Add("Tsina_Det", "Ціна");
            dataGridView1.Columns.Add("Dodat_Det", "Додаткова інформація");
            dataGridView1.Columns.Add("IsNew", String.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetString(5), RoWState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            if (k == 1)
            {
                string queryString = $"select * from detali";
                SqlCommand command = new SqlCommand(queryString, db.GetConnection());
                db.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRow(dgw, reader);
                }
                reader.Close();
            }
            else if (k == 2)
            {
                string queryString = $"select * from riduna";
                SqlCommand command = new SqlCommand(queryString, db.GetConnection());
                db.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRow(dgw, reader);
                }
                reader.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_Id.Text = row.Cells[0].Value.ToString();
                textBox_Tip.Text = row.Cells[1].Value.ToString();
                textBox_Nazva.Text = row.Cells[2].Value.ToString();
                textBox_Kilkist.Text = row.Cells[3].Value.ToString();
                textBox_Tsina.Text = row.Cells[4].Value.ToString();
                richTextBox1_Det.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                NewDetForm mainf = new NewDetForm();
                mainf.Show();
            }
            if (k == 2)
            {
                NewRidForm mainf = new NewRidForm();
                mainf.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox_Id.Text = "";
            textBox_Tip.Text = "";
            textBox_Nazva.Text = "";
            textBox_Kilkist.Text = "";
            textBox_Tsina.Text = "";
            richTextBox1_Det.Text = "";
        }

        public void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            if (k == 1)
            {
                string searchString = $"select * from detali where concat (id_Det, Tip_Det, Nazva_Det, Kilkist_Det, Tsina_Det, Dodat_Det) like '%" + textBox_poisk.Text + "%' ";

                SqlCommand command = new SqlCommand(searchString, db.GetConnection());

                db.OpenConnection();
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    ReadSingleRow(dgw, read);
                }
                read.Close();
            }

            if (k == 2)
            {
                string searchString = $"select * from riduna where concat (id_Rid, Tip_Rid, Nazva_Rid, Kilkist_Rid, Tsina_Rid, Dodat_Rid) like '%" + textBox_poisk.Text + "%' ";

                SqlCommand command = new SqlCommand(searchString, db.GetConnection());

                db.OpenConnection();
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    ReadSingleRow(dgw, read);
                }
                read.Close();
            }
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RoWState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[6].Value = RoWState.Deleted;
        }

        private void Update()
        {
            db.OpenConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RoWState)dataGridView1.Rows[index].Cells[6].Value;

                if (rowState == RoWState.Existed)
                    continue;

                if (rowState == RoWState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    if (k == 1)
                    {
                        var deleteQuery = $"delete from detali where id_Det = {id}";
                        var command = new SqlCommand(deleteQuery, db.GetConnection());
                        command.ExecuteNonQuery();
                    }
                    else if (k == 2)
                    {
                        var deleteQuery = $"delete from riduna where id_Rid = {id}";
                        var command = new SqlCommand(deleteQuery, db.GetConnection());
                        command.ExecuteNonQuery();
                    }



                }

                if (rowState == RoWState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var type = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Nazva = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var Kilkist = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var Tsina = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var Dodat = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    if (k == 1)
                    {
                        var changeQuery = $"update detali set Tip_Det ='{type}',Nazva_Det ='{Nazva}',Kilkist_Det ='{Kilkist}',Tsina_Det ='{Tsina}',Dodat_Det ='{Dodat}' where id_Det = '{id}'";
                        var command = new SqlCommand(changeQuery, db.GetConnection());
                        command.ExecuteNonQuery();
                    }

                    if (k == 2)
                    {
                        var changeQuery = $"update riduna set Tip_Rid ='{type}',Nazva_Rid ='{Nazva}',Kilkist_Rid ='{Kilkist}',Tsina_Rid ='{Tsina}',Dodat_Rid ='{Dodat}' where id_Rid = '{id}'";
                        var command = new SqlCommand(changeQuery, db.GetConnection());
                        command.ExecuteNonQuery();
                    }

                }
            }
            db.CloseConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button_Delit_Click(object sender, EventArgs e)
        {
            deleteRow();
            textBox_Id.Text = "";
            textBox_Tip.Text = "";
            textBox_Nazva.Text = "";
            textBox_Kilkist.Text = "";
            textBox_Tsina.Text = "";
            richTextBox1_Det.Text = "";
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_Id.Text;
            var type = textBox_Tip.Text;
            var Nazva = textBox_Nazva.Text;
            int Kilkist;
            int Tsina;
            var Dodat = richTextBox1_Det.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_Kilkist.Text, out Kilkist) && int.TryParse(textBox_Tsina.Text, out Tsina))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, type, Nazva, Kilkist, Tsina, Dodat);
                    dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RoWState.Modified;
                }
                else
                {
                    MessageBox.Show("Кількість та ціна мають бути задані в числовому форматі!");
                }
            }
        }

        private void button_Zmin_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Admining_Click(object sender, EventArgs e)
        {
            AdminForm mainf = new AdminForm();
            mainf.Show();
        }

        private void Asort_Click(object sender, EventArgs e)
        {

        }

        private void Asort_Rid_Click(object sender, EventArgs e)
        {
            k = 2;
            if (ki < 1)
            {
                CreateColumns();
            }
            ki = 1;

            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns[6].Visible = false;
            textBox_Id.Text = "";
            textBox_Tip.Text = "";
            textBox_Nazva.Text = "";
            textBox_Kilkist.Text = "";
            textBox_Tsina.Text = "";
            richTextBox1_Det.Text = "";
            label6.Text = "Літрів.";
            label7.Text = "$ \\ Літр.";
            //----------------
            richTextBox1_Det.Enabled = true;
            panel_Button.Enabled = true;
            panel4.Enabled = true;
            panel3.Enabled = true;
        }

        private void Asort_Det_Click(object sender, EventArgs e)
        {
            k = 1;

            if (ki < 1)
            {
                CreateColumns();
            }
            ki = 1;

            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns[6].Visible = false;
            textBox_Id.Text = "";
            textBox_Tip.Text = "";
            textBox_Nazva.Text = "";
            textBox_Kilkist.Text = "";
            textBox_Tsina.Text = "";
            richTextBox1_Det.Text = "";
            label6.Text = "Штук.";
            label7.Text = "$ \\ Штуку.";
            //----------------
            richTextBox1_Det.Enabled = true;
            panel_Button.Enabled = true;
            panel4.Enabled = true;
            panel3.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Koristuvach.Text = $"{_user.Login}:{_user.Status}";
            IsAdmin();
            richTextBox1_Det.Enabled = false;
            panel_Button.Enabled = false;
            panel4.Enabled = false;
            panel3.Enabled = false;
        }
    }
}
