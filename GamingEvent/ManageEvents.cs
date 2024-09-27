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
    public partial class ManageEvents : Form
    {
        DataBaseHelper dbHelper;
        DataRemove dataRemove;
        public ManageEvents()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            dataRemove = new DataRemove();
            LoadTables();
        }

        private void LoadTables()
        {
            dataGridViewEvents.DataSource = dbHelper.LoadEvents();
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridViewEvents.Columns["Image"] != null)
            {
                dataGridViewEvents.Columns["Image"].Visible = false;
            }

        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            AddEvents addEvents = new AddEvents();
            addEvents.Show();
            this.Hide();

        }

     

        private void dataGridViewEvents_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridViewEvents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                // Get the Event ID of the clicked row
                string eventID = dataGridViewEvents.Rows[e.RowIndex].Cells["EventID"].Value.ToString();

                // Open the EventDetails form, passing the event ID
                EventDetailForm eventDetail = new EventDetailForm(eventID);
                eventDetail.Show(); 
                LoadTables();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string removeId = removeText.Text;

            if (removeId == "")
            {
                MessageBox.Show("Enter an ID to Remove. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!dbHelper.CheckEvent(removeId))
            {
                MessageBox.Show("Invalid ID. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool isRemoved = dataRemove.RemoveEventFromDB(removeId);
                if (isRemoved)
                {
                    MessageBox.Show("Event Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEvents.DataSource = null;
                    dataGridViewEvents.DataSource = dbHelper.LoadEventsToTable();
                    dataGridViewEvents.Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to Remove Event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
