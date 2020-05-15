using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;


namespace PF.DVDCentral.MVCUI.ViewModels
{
    public class CustomerOrders
    {
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
    }
}