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
    public partial class AddEvents : Form
    {
        DataAddHelper addHelper;
        DataBaseHelper dataBaseHelper;
        public AddEvents()
        {
            InitializeComponent();
            addHelper = new DataAddHelper();
            dataBaseHelper = new DataBaseHelper();
            InitateDateTime();
        }

        private void InitateDateTime()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.MinDate = DateTime.Today;
        }

        private byte[] eventImage;

        private void uploadIMG_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files| *.jpg;*.jpeg;*.png;*.bmp";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    eventImage = File.ReadAllBytes(openFileDialog.FileName);
                }
            }
        }

        private bool ValidateInputs()
        {
            string ID = textBoxID.Text;
            string name = textBoxName.Text;
            string location = textBoxLocation.Text;
            string description = descBox.Text;
            DateTime date = dateTimePicker1.Value;
            string ticketPriceText = textBoxTicketPrice.Text;

            if (ID == "" || name =="" || description =="" || location == "")
            {
                MessageBox.Show("Please Fill all the Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (dataBaseHelper.CheckEvent(ID))
            {
                MessageBox.Show("ID Exists Already. Please Enter Different ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!decimal.TryParse(ticketPriceText, out decimal ticketPrice))
            {
                MessageBox.Show("Please enter a valid ticket price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(eventImage == null)
            {
                MessageBox.Show("Please upload an event image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void addEventBtn_Click(object sender, EventArgs e)
        {
            string ID = textBoxID.Text;
            string name = textBoxName.Text;
            string location = textBoxLocation.Text;
            string description = descBox.Text;
            DateTime date = dateTimePicker1.Value;

            if (ValidateInputs())
            {
                decimal ticketPrice = decimal.Parse(textBoxTicketPrice.Text);
                bool success = addHelper.AddEvent(ID, name, location, date, description, eventImage, ticketPrice);
                if(success)
                {
                    MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageEvents manageEvents = new ManageEvents();
                    manageEvents.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ManageEvents manageEvents = new ManageEvents();
            manageEvents.Show();
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
