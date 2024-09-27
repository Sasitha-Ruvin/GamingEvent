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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GamingEvent
{
    public partial class ManageParticipants : Form
    {
        DataBaseHelper helper;
        DataRemove dataRemove;
        public ManageParticipants()
        {
            InitializeComponent();
            helper = new DataBaseHelper();
            dataRemove = new DataRemove();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTables()
        {
            dataGridViewPart.DataSource = helper.LoadParticipantsToTable();
            dataGridViewPart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void ManageParticipants_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string removeId = removeText.Text;

            if(removeId == "")
            {
                MessageBox.Show("Enter an ID to Remove. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!helper.CheckUser(removeId))
            {
                MessageBox.Show("Invalid ID. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool isRemoved = dataRemove.RemoveParticipantFromDB(removeId);
                if(isRemoved)
                {
                    MessageBox.Show("User Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewPart.DataSource = null;
                    dataGridViewPart.DataSource = helper.LoadParticipants();
                    dataGridViewPart.Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to Remove User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridViewPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object eventID = dataGridViewPart.Rows[e.RowIndex].Cells["ParticipantID"].Value;

                removeText.Text = eventID?.ToString();
            }
        }
    }
}
