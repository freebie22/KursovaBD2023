using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pid_Kursach
{
    public partial class MainMenu : Form
    {
        private readonly checkUser _user;

        DataBase db = new DataBase();

        public MainMenu(checkUser user)
        {
            InitializeComponent();
            _user = user;
            
        }



        private void маркиАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarNames carNames = new CarNames();
            carNames.Show();
        }

        private void IsAdmin()
        {
            продажToolStripMenuItem.Enabled = _user.IsAdmin;
            менеджериToolStripMenuItem.Enabled = _user.IsAdmin;
            користувачіToolStripMenuItem.Enabled = _user.IsAdmin;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "Активний користувач: " + $"{_user.Login}";
            продажToolStripMenuItem.Enabled = false;
            менеджериToolStripMenuItem.Enabled = false;
            користувачіToolStripMenuItem.Enabled = false;
            IsAdmin();
        }

        private void моделіАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarModels carModels = new CarModels();
            carModels.Show();
        }

        private void типиКузовівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarTypes carTypes = new CarTypes();
            carTypes.Show();
        }

        private void менеджериToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Managers managers = new Managers();
            managers.Show();
        }

        private void клієнтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients client = new Clients();
            client.Show();
        }
    }
    }

