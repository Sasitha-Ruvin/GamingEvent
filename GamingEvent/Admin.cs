using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEvent
{
    public class Admin : Person
    {
        public string AdminID { get; set; }
        private string username;
        private string password;

        public string _username
        {
            get { return username; }
            set { username = value; }
        }

        public string _password
        {
            get { return password; }
            set { password = value; }
        }

        public Admin(string adminID,string username, string password, string name, string address, string email, int contact) : base(name, address, email, contact)
        {
            AdminID = adminID;
            _username = username;
            _password = password;
        }
    }
}
