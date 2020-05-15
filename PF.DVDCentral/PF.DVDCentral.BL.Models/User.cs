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
        [DisplayName("User Id")]

        public int UserId { get; set; }
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [DisplayName("LastName")]

        public string LastName { get; set; }
        [DisplayName("Password")]

        public string Password { get; set; }

        public User()
        {

        }

        public User(int userid, string password)
        {
            // A User is trying to log in
            UserId = userid;
            Password = password;


        }

        public User(int id, int userid, string firstname, string lastname, string password)
        {
            //Updated a user
            UserId = userid;
            Password = password;
            Id = id;
            FirstName = firstname;
            Password = password;

        }
        public User(int userid, string firstname, string lastname, string password)
        {
            //creating a user
            UserId = userid;
            Password = password;
            FirstName = firstname;
            Password = password;

        }
    }
}
