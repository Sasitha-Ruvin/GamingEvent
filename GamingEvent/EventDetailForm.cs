using GamingEvent.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingEvent
{
    public partial class EventDetailForm : Form
    {
        private DataBaseHelper dbHelper;
        private DataAddHelper addHelper;
        private string eventID;
        private byte[] eventImage;
        public EventDetailForm(string selectedEventID)
        {

            dbHelper = new DataBaseHelper();
            addHelper = new DataAddHelper();
            eventID = selectedEventID;
            InitializeComponent();
            LoadDetails();
            saveButton.Enabled = false;


        }

        private void LoadDetails()
        {
            Event evt = dbHelper.Event.Find(e=>e.EventID == eventID);
            if (evt != null)
            {
                textBoxID.Text = evt.EventID;
                textBoxName.Text = evt.EventName;
                textBoxLocation.Text = evt.Location;
                dateTimePicker1.Value = evt.EventDate;
                descBox.Text = evt.Description;

                if (evt.Image != null)
                {
                    eventImage = evt.Image;
                    using (MemoryStream ms = new MemoryStream(eventImage))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
            EnableEditing(false);


        }

        private void EnableEditing(bool enable)
        {
            textBoxName.ReadOnly = !enable;
            textBoxLocation.ReadOnly = !enable;
            descBox.ReadOnly = !enable;
            dateTimePicker1.Enabled = enable;
            uploadIMG.Enabled = enable; 
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            EnableEditing(true); 
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string location = textBoxLocation.Text;
            DateTime date = dateTimePicker1.Value;
            string description = descBox.Text;

            if (ValidateInputs())
            {
                decimal ticketPrice = decimal.Parse(textBoxTicketPrice.Text);
                bool success = addHelper.UpdateEvent(eventID, name, location, date, description, eventImage, ticketPrice);
                if (success)
                {
                    MessageBox.Show("Event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageEvents manageEvents = new ManageEvents();
                    manageEvents.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private bool ValidateInputs()
        {
            string ticketPriceText = textBoxTicketPrice.Text;

            if (textBoxName.Text == "" || textBoxLocation.Text == "" || descBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (eventImage == null)
            {
                MessageBox.Show("Please upload an event image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!decimal.TryParse(ticketPriceText, out decimal ticketPrice))
            {
                MessageBox.Show("Please enter a valid ticket price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void uploadIMG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    eventImage = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ManageEvents manageEvents = new ManageEvents();
            manageEvents.Show();
            this.Close();
        }
    }
}
