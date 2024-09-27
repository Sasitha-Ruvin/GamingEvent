using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingEvent
{
    public class DataBaseHelper
    {
        public List<Participant> Participants;
        public List<Event> Event;
        public List<Bookings> Bookings;

        public DataBaseHelper()
        {
            Event = LoadEvents();
        }

        //Connection String
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Event> LoadEvents()
        {
            List<Event> events = new List<Event>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Event";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Read each field and store them in the Event object
                        string eventID = reader["EventID"].ToString();
                        string eventName = reader["EventName"].ToString();
                        string description = reader["Description"].ToString();
                        DateTime eventDate = Convert.ToDateTime(reader["EventDate"]);
                        string location = reader["Location"].ToString();
                        byte[] image = reader["Image"] != DBNull.Value ? (byte[])reader["Image"] : null;

                        // Create the Event object
                        Event evt = new Event(eventID, eventName, description, eventDate, location, image);

                        // Add to the list
                        events.Add(evt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message, "Connection Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return events;
        }

        //Getting Customer Count
        public int GetCustomerCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 ParticipantID FROM Participants ORDER BY ParticipantID DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string latestcustomer = result.ToString();
                        string numericPart = latestcustomer.Substring(3);
                        int latestCustomerID = int.Parse(numericPart);
                        return latestCustomerID;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public bool CheckIDExistance(string participantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT (*) FROM Participants WHERE ParticipantID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", participantID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }

        }

        //Generating Unique Customer ID
        public string GenerateCustomerID()
        {
            int latestCustomer = GetCustomerCount();
            while (CheckIDExistance("CUS" + latestCustomer.ToString("0000")))
            {
                latestCustomer++;
            }
            return "CUS" + latestCustomer.ToString("0000");

        }

        public DataTable LoadEventsToTable()
        {
            DataTable events = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EventID, EventName, Description, EventDate, Location FROM Event";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        events.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message, "Connection Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return events;
        }
         public DataTable LoadParticipantsToTable()
        {
            DataTable participants = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ParticipantID, Name, Address, Email, Contact FROM Participants";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        participants.Load(reader);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message, "Connection Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return participants;
         }

        public DataTable LoadBookingsToTable()
        {
            DataTable bookings = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Bookings";
                    using(SqlCommand command =new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        bookings.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message, "Connection Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bookings;
        }

        // Method to Fetch Event Image by EventID
        public byte[] GetEventImage(string eventID)
        {
            byte[] eventImage = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Image FROM Event WHERE EventID = @eventID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@eventID", eventID);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            eventImage = (byte[])result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to fetch image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return eventImage;
        }

        public bool UpdateEvent(string eventID, string eventName, string location, DateTime eventDate, string description, byte[] eventImage)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Event SET EventName = @EventName, Location = @Location, EventDate = @EventDate, Description = @Description, Image = @Image WHERE EventID = @EventID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", eventID);
                        command.Parameters.AddWithValue("@EventName", eventName);
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@EventDate", eventDate);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Image", eventImage);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update event: " + ex.Message, "Update Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
