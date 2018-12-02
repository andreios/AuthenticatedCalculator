using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticatedCalculator
{
    class User
    {
        //constructor
        public User(string user, string pass, string access)
        {
            Username = user;
            Password = pass;
            AccessLevel = access;
        }
              
        //property declarations
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }

        

    }
}
