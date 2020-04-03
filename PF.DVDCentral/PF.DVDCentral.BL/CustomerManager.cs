﻿using System;
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
        public static int Insert(out int id, string firstname, string lastname, string address, string city, string state, string zip, string phone, int userId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer newrow = new tblCustomer();

                    newrow.UserId = userId;
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
                int result = Insert(out id, customer.FirstName, customer.LastName, customer.Address, customer.City, customer.State, customer.Phone, customer.Zip, customer.UserId);
                customer.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, string firstname, string lastname, string address, string city, string state, string zip, string phone, int userId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer updaterow = (from dt in dc.tblCustomers
                                           where dt.Id == id
                                           select dt).FirstOrDefault();
                    
                    updaterow.UserId = userId;
                    updaterow.Phone = phone;
                    updaterow.Zip = zip;
                    updaterow.Address = address;
                    updaterow.City = city;
                    updaterow.State = state;
                    updaterow.LastName = lastname;
                    updaterow.FirstName = firstname;
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
            return Update(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.City, customer.State, customer.Phone, customer.Zip, customer.UserId);
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
                            FirstName = dt.FirstName,
                            LastName = dt.LastName,
                            Phone = dt.Phone,
                            Zip = dt.Zip,
                            City = dt.City,
                            State = dt.State,
                            UserId = dt.UserId,
                            Address = dt.Address

                        }); ;
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
                        return new Customer { Id = row.Id, Address = row.Address, UserId = row.UserId, State = row.State, City = row.City, FirstName = row.FirstName, LastName = row.LastName, Phone = row.Phone, Zip = row.Zip };
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