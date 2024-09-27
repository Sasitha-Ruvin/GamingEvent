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
    public partial class ViewBookings : Form
    {
        DataBaseHelper baseHelper;
        public ViewBookings()
        {
            baseHelper = new DataBaseHelper();
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void LoadTables()
        {
            dataGridViewBookings.DataSource = baseHelper.LoadBookingsToTable();
            dataGridViewBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ViewBookings_Load(object sender, EventArgs e)
        {
            LoadTables();
        }
    }
}
