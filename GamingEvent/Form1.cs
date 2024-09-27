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
    public partial class Form1 : Form
    {
        Validations validations;
        public Form1()
        {
            InitializeComponent();
            validations = new Validations();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void InitateComboBox()
        {
            comboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUser.Items.Add("Admin");
            comboBoxUser.Items.Add("Participant");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitateComboBox();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string usertype = comboBoxUser.SelectedItem?.ToString();
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if(username == "" || password == "")
            {
                MessageBox.Show("Please Enter Both Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(usertype == "Admin")
                {
                    bool isValid = validations.ValidateAdminLogin(username, password);
                    if(isValid)
                    {
                        AdminDashboard adminDashboard = new AdminDashboard();
                        this.Hide();
                        adminDashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(usertype == "Participant")
                {
                    bool isValid = validations.ParticipantLogin(username, password);
                    if (isValid)
                    {
                        UserDashboard userDashboard = new UserDashboard();
                        userDashboard.Show();
                        this.Hide();
                      
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    
                     MessageBox.Show("Invalid UserType. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

            }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxPass.Checked;
        }
    }
}
