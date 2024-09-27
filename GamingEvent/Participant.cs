using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEvent
{
    public class Participant:Person
    {
        public string ParticipantID { get; set; }

        private string username { get; set; }

        private string password { get; set; }

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

        public Participant(string id,string name, string username, string password, string address, string email, int contact):base(name, address, email, contact)
        {
            ParticipantID = id;
            _username = username;
            _password = password;
        }
    }
}
