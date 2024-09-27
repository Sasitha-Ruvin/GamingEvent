using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingEvent.DatabaseHelpers
{
    public class DataRemove
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool RemoveEventFromDB(string eventID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string delQuery = "DELETE FROM Event WHERE EventID = @EventID";
                    using (SqlCommand command = new SqlCommand(delQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", eventID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool RemoveParticipantFromDB(string participantID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string delQuery = "DELETE FROM Participants WHERE ParticipantID = @ParticipantID";
                    using (SqlCommand command = new SqlCommand(delQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ParticipantID", participantID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool RemoveBookingFromDB(int bookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string delQuery = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                    using (SqlCommand command = new SqlCommand(delQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", bookingID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
