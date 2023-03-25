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
    public partial class AdminForm : Form
    {
        DataBase db = new DataBase();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("login", "Логін");
            dataGridView1.Columns.Add("pass", "Пароль");
            var checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Kod";
            dataGridView1.Columns.Add(checkColumn);

        }

        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetBoolean(3));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string querryString = $"SELECT * FROM users";
            SqlCommand command = new SqlCommand(querryString, db.GetConnection());
            db.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(reader);
            }
            reader.Close();

            db.CloseConnection();
        }



        private void button_Save_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                var isadmin = dataGridView1.Rows[index].Cells[3].Value.ToString();

                var changeQuery = $"UPDATE users SET Kod = {isadmin} WHERE id = {id}";

                var command = new SqlCommand(changeQuery, db.GetConnection());
                command.ExecuteNonQuery();

            }
            db.CloseConnection();

            RefreshDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.OpenConnection();

            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            var deleteQuerry = $"DELETE FROM users WHERE id = {id}";

            var command = new SqlCommand(deleteQuerry, db.GetConnection());
            command.ExecuteNonQuery();
            db.CloseConnection();
            RefreshDataGrid();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
        }
    }
}
