using GamingEvent.DatabaseHelpers;
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
    public partial class UserBookings : Form
    {
        DataBaseHelper dbHelper;
        DataRemove dataRemove;
        private string LogInUser;
        public UserBookings(string username)
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            dataRemove = new DataRemove();
            this.LogInUser = username;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserBookings_Load(object sender, EventArgs e)
        {
            Participant participant = dbHelper.Participants.Find(p => p._username == LogInUser);
            if (participant != null)
            {
                List<BookedEvent> bookedEvents = dbHelper.GetBookings(participant.ParticipantID);
                dataGridViewBookings.DataSource = bookedEvents;
                dataGridViewBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int removeID;
            if(!int.TryParse(removeText.Text, out removeID))
            {
                MessageBox.Show("Invalid Booking ID. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool isRemoved = dataRemove.RemoveBookingFromDB(removeID);
                if (isRemoved)
                {
                    MessageBox.Show("Booking Cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewBookings.Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to Remove Booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard(LogInUser);
            this.Close();
            userDashboard.Show();
        }
    }
}
