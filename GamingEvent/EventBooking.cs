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
    public partial class EventBooking : Form
    {
        private string LoggedUser;
        DataBaseHelper baseHelper;
        DataAddHelper addHelper;
        public EventBooking(string username)
        {
            this.LoggedUser = username;
            baseHelper = new DataBaseHelper();
            addHelper = new DataAddHelper();
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            dataGridView1.DataSource = baseHelper.LoadEventsToTable();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex >=0)
            {
                object eventID = dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value;

                textBoxID.Text = eventID?.ToString();
            }
        }

        private decimal CalculateCost(string EventID, int Participants)
        {
            decimal cost = 0;

            try
            {
                decimal ticketPrice = baseHelper.GetTicketPrice(EventID);

                cost = ticketPrice * Participants;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to calculate total cost: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cost;
        }

        private void bookbtn_Click(object sender, EventArgs e)
        {
            string eventID = textBoxID.Text;
            int participants;
            if(!int.TryParse(textBoxParticipants.Text, out participants))
            {
                MessageBox.Show("Invalid Participants. Please Enter Numerical Whole Values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Participant participant = baseHelper.Participants.Find(p => p._username == LoggedUser);

                if(eventID == "")
                {
                    MessageBox.Show("Enter a Event ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!baseHelper.CheckEvent(eventID))
                {
                    MessageBox.Show("Invalid ID. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    decimal total = CalculateCost(eventID, participants);

                    Event evt = baseHelper.LoadEvents().Find(ev => ev.EventID == eventID);

                    if (evt != null)
                    {
                        BookedEvent bookedEvent = new BookedEvent(eventID, participant.ParticipantID, participants, total);
                        baseHelper.Bookings.Add(bookedEvent);
                        addHelper.AddBookedEventToDatabase(bookedEvent);

                        // Display Event Name, Event Date, and Location in the MessageBox
                        MessageBox.Show($"Thank you for your Booking \n" +
                            $"EventID: {eventID}\n" +
                            $"Event Name: {evt.EventName}\n" +
                            $"Event Date: {evt.EventDate.ToShortDateString()}\n" +
                            $"Location: {evt.Location}\n" +
                            $"No. Of Participants: {participants}\n" +
                            $"Total: {total}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Event not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard(LoggedUser);
            userDashboard.Show();
            this.Close();
        }
    }
}
