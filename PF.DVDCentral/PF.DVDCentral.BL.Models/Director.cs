using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.DVDCentral.BL.Models
{
    public class Director

    {
        public int Id { get; set; }
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        // Calculated Full Name
        [DisplayName("Name")]

        public string FullNameFirst
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
