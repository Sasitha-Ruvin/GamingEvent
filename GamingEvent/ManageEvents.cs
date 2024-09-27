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
        public ManageEvents()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
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
    }
}
