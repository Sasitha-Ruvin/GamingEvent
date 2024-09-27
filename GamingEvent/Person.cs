using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingEvent
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Address { get; set; } 

        public string Email { get; set; }   

        public int Contact { get; set; }    

        public Person(string name, string address, string email, int contact)
        {
            Name = name;
            Address = address;
            Email = email;
            Contact = contact;
        }
    }
}
