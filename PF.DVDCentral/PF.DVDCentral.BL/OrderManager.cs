using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.PL;



namespace PF.DVDCentral.BL
{
    public class OrderManager
    {
        public static int Insert(out int id, int customerId, DateTime orderdate, int username, DateTime shipdate)
        {
               try
                {
                    using (DVDCentralEntities dc = new DVDCentralEntities())
                    {
                        tblOrder newrow = new tblOrder();

                    newrow.CustomerId = customerId;
                    newrow.OrderDate = orderdate;
                    newrow.ShipDate = shipdate;
                    newrow.UserName = username;
                    newrow.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(dt => dt.Id) + 1 : 1;
                        id = newrow.Id;

                        dc.tblOrders.Add(newrow);
                        return dc.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        

    public static int Insert(Order order)
    {
        try
        {
            int id = 0;
            int result = Insert(out id, order.CustomerId, order.OrderDate, order.UserName, order.ShipDate);
            order.Id = id;
            return result;
        }
        catch (Exception ex)
        {
                throw ex;

            }
    }
        public static int Update(int id, int customerId, DateTime orderdate, int username, DateTime shipdate)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder updaterow = (from dt in dc.tblOrders
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    updaterow.CustomerId = customerId;
                    updaterow.OrderDate = orderdate;
                    updaterow.ShipDate = shipdate;
                    updaterow.UserName = username;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Order order)
        {
            return Update(order.Id, order.CustomerId, order.OrderDate, order.UserName, order.ShipDate);
        }

        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder deleterow = (from dt in dc.tblOrders
                                             where dt.Id == id
                                             select dt).FirstOrDefault();

                    dc.tblOrders.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Order> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Order> orders = new List<Order>();
                    foreach (tblOrder dt in dc.tblOrders)
                    {
                        orders.Add(new Order
                        {
                            Id = dt.Id,
                            CustomerId = dt.CustomerId,
                            OrderDate = dt.OrderDate,
                            ShipDate = dt.ShipDate,
                            UserName = dt.UserName
                           
                        }) ;
                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder row = (from dt in dc.tblOrders
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Order {
                            Id = row.Id,
                            CustomerId = row.CustomerId,
                            OrderDate = row.OrderDate,
                            ShipDate = row.ShipDate,
                            UserName = row.UserName
                        };
                    else
                        throw new Exception("Row was not found.");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Order LoadByCustomerId(int customerId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder row = (from dt in dc.tblOrders
                                    where dt.CustomerId == customerId
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Order
                        {
                            Id = row.Id,
                            CustomerId = row.CustomerId,
                            OrderDate = row.OrderDate,
                            ShipDate = row.ShipDate,
                            UserName = row.UserName
                        };
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
