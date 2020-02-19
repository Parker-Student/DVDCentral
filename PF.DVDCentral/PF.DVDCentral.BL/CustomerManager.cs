using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.PL;

namespace PF.DVDCentral.BL
{
    public class CustomerManager
    {
        public static int Insert(out int id, string firstname, string lastname, string address, string city, string state, string zip, string phone, string UserId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer newrow = new tblCustomer();

                    newrow.UserId = UserId;
                    newrow.Phone = phone;
                    newrow.Zip = zip;
                    newrow.Address = address;
                    newrow.City = city;
                    newrow.State = state;
                    newrow.LastName = lastname;
                    newrow.FirstName = firstname;
                    newrow.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;



                    dc.tblCustomers.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Customer customer)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, customer.Description);
                customer.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer updaterow = (from dt in dc.tblCustomers
                                           where dt.Id == id
                                           select dt).FirstOrDefault();

                    updaterow.Description = description;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Customer customer)
        {
            return Update(customer.Id, customer.Description);
        }
        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer deleterow = (from dt in dc.tblCustomers
                                           where dt.Id == id
                                           select dt).FirstOrDefault();

                    dc.tblCustomers.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Customer> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Customer> customers = new List<Customer>();
                    foreach (tblCustomer dt in dc.tblCustomers)
                    {
                        customers.Add(new Customer
                        {
                            Id = dt.Id,
                            Description = dt.Description
                        });
                    }
                    return customers;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Customer LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer row = (from dt in dc.tblCustomers
                                     where dt.Id == id
                                     select dt).FirstOrDefault();

                    if (row != null)
                        return new Customer { Id = row.Id, Description = row.Description };
                    else
                        throw new Exception("Row was not found.");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}