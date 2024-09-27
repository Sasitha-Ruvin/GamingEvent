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
    public partial class SignUp : Form
    {
        DataBaseHelper dataBaseHelper;
        DataAddHelper dataAddHelper;
        public SignUp()
        {
            InitializeComponent();
            dataBaseHelper = new DataBaseHelper();
            dataAddHelper = new DataAddHelper();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string ID = dataBaseHelper.GenerateCustomerID();
            string name = textBoxName.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            int contact;
            if(!int.TryParse(textBoxContact.Text, out contact))
            {
                MessageBox.Show("Invalid Contact. Please Enter Numerical Values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(name == "" || username =="" || password == "" || email == "" || address == "")
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = dataAddHelper.AddUser(ID, name, username, password, email, address, contact);
                if (success)
                {
                    MessageBox.Show("Registration Successful. Please use the Username and Password to Login", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Occured. Registration Failed. Please try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

      

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
