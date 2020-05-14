using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.PL;



namespace PF.DVDCentral.BL
{
    public class OrderItemManager
    {
        public static int Insert(out int id, int movieId, int orderId, int quantity)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem newrow = new tblOrderItem();

                    newrow.MovieId = movieId;
                    newrow.OrderId = orderId;
                    newrow.Quantity = quantity;
                    newrow.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;

                    dc.tblOrderItems.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int Insert(OrderItem orderItem)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, orderItem.MovieId, orderItem.OrderId, orderItem.Quantity);
                orderItem.Id = id;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static int Update(int id, int movieId, int orderId, int quantity)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem updaterow = (from dt in dc.tblOrderItems
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    updaterow.MovieId = movieId;
                    updaterow.OrderId = orderId;
                    updaterow.Quantity = quantity;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(OrderItem orderItem)
        {
            return Update(orderItem.Id, orderItem.MovieId, orderItem.OrderId, orderItem.Quantity);
        }

        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem deleterow = (from dt in dc.tblOrderItems
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    dc.tblOrderItems.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<OrderItem> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<OrderItem> orderItems = new List<OrderItem>();
                    foreach (tblOrderItem dt in dc.tblOrderItems)
                    {
                        orderItems.Add(new OrderItem
                        {
                            Id = dt.Id,
                            MovieId = dt.MovieId,
                            OrderId = dt.OrderId,
                            Quantity = dt.Quantity,

                        });
                    }
                    return orderItems;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static OrderItem LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem row = (from dt in dc.tblOrderItems
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new OrderItem
                        {
                            Id = row.Id,
                            MovieId = row.MovieId,
                            OrderId = row.OrderId,
                            Quantity = row.Quantity

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
        public static OrderItem LoadByOrderId(int orderId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem row = (from dt in dc.tblOrderItems
                                        where dt.OrderId == orderId
                                        select dt).FirstOrDefault();

                    if (row != null)
                        return new OrderItem
                        {
                            Id = row.Id,
                            MovieId = row.MovieId,
                            OrderId = row.OrderId,
                            Quantity = row.Quantity

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
