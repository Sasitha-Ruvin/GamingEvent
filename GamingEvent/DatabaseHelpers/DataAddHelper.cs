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
    public class DataAddHelper
    {
        //Connection String
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool AddUser(string ID, string name, string username, string password, string email, string address, int contact)
        {
            Validations validations = new Validations();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Participants (ParticipantID, Username, Password, Name, Address, Email, Contact)" +
                        "VALUES (@ID, @Username, @Password, @Name, @Address, @Email, @Contact)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Contact", contact);

                        if (validations.CheckUsernameExistance(username))
                        {
                            MessageBox.Show("Username is already taken. Please Choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            int result = command.ExecuteNonQuery();
                            return result > 0;
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

        public bool AddEvent(string ID, string Name, string location, DateTime date, string description, byte[] image)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Event(EventID, EventName, Description, EventDate, Location, Image)" +
                        "VALUES (@ID, @Name, @Desc, @Date, @Location, @Image)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Desc", description);
                        command.Parameters.AddWithValue("@Location", location);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Image", image);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to update event details in the database
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
