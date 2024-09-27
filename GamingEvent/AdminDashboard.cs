using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingEvent
{
    public partial class AdminDashboard : Form
    {
        DataBaseHelper baseHelper;
        public AdminDashboard()
        {
            baseHelper = new DataBaseHelper();
            InitializeComponent();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void manageEvents_Click(object sender, EventArgs e)
        {
            ManageEvents manageEvents = new ManageEvents();
            manageEvents.Show();
            this.Hide();
        }

        private void LoadTables()
        {
            dataGridViewEvents.DataSource = baseHelper.LoadEventsToTable();
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridViewEvents.Columns["Image"] != null)
            {
                dataGridViewEvents.Columns["Image"].Visible = false;
            }

            dataGridViewParticipants.DataSource = baseHelper.LoadParticipantsToTable();
            dataGridViewParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadTables();

        }

        private void manageUsers_Click(object sender, EventArgs e)
        {
            ManageParticipants manageParticipants = new ManageParticipants();
            this.Hide();
            manageParticipants.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
