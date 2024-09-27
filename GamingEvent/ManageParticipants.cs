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
    public partial class ManageParticipants : Form
    {
        DataBaseHelper helper;
        public ManageParticipants()
        {
            InitializeComponent();
            helper = new DataBaseHelper();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTables()
        {
            dataGridViewPart.DataSource = helper.LoadParticipantsToTable();
            dataGridViewPart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void ManageParticipants_Load(object sender, EventArgs e)
        {
            LoadTables();
        }
    }
}
