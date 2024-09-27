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
    public partial class UserDashboard : Form
    {
        private string LoggedInUser;
        DataBaseHelper baseHelper;
        public UserDashboard(string username)
        {
            this.LoggedInUser = username;
            baseHelper = new DataBaseHelper();
            InitializeComponent();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            EventBooking eventBooking = new EventBooking(LoggedInUser);
            this.Hide();
            eventBooking.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadTables()
        {
            dataGridViewEvents.DataSource = baseHelper.LoadEventsToTable();
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonBookings_Click(object sender, EventArgs e)
        {
            UserBookings userBookings = new UserBookings(LoggedInUser);
            this.Hide();
            userBookings.Show();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadTables();
        }
    }
}
