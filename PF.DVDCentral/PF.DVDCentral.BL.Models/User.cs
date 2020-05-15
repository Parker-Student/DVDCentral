using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.DVDCentral.BL.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("User Name")]

        public string UserName { get; set; }
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [DisplayName("Password")]

        public string Password { get; set; }

        public User()
        {

        }

        public User(string username, string password)
        {
            // A User is trying to log in
            UserName = username;
            Password = password;


        }

        public User(int id, string username, string firstname, string lastname, string password)
        {
            //Updated a user
            UserName = username;
            Password = password;
            Id = id;
            FirstName = firstname;
            Password = password;

        }
        public User(string username, string firstname, string lastname, string password)
        {
            //creating a user
            UserName = username;
            Password = password;
            FirstName = firstname;
            Password = password;

        }
    }
}
