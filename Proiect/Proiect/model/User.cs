using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.model
{
    public class User
    {
        private int Id { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password; 
        }

    }

    public class Admin : User
    {
        public Admin(int id, string username, string password) : base(id, username, password)
        {
        }
    }


    public class NormalUser : User
    {
        public NormalUser(int id, string username, string password) : base(id, username, password)
        {
        }
    }

}
