using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.PL;
namespace PF.DVDCentral.BL
{
    public class UserManager
    {
        private static string GetHash(string passcode)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(passcode);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));

            }
        }

        public static void Map()
        {

        }

        public static void Insert(int userid, string firstname, string lastname, string password)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser newuser = new tblUser();
                    newuser.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(u => u.Id) + 1 : 1;
                    newuser.Password = GetHash(password);
                    newuser.FirstName = firstname;
                    newuser.LastName = lastname;
                    newuser.UserId = userid;

                    dc.tblUsers.Add(newuser);
                    dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Insert(User user)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser newuser = new tblUser();
                    newuser.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(u => u.Id) + 1 : 1;
                    newuser.Password = GetHash(user.Password);
                    newuser.FirstName = user.FirstName;
                    newuser.LastName = user.LastName;
                    newuser.UserId = user.UserId;

                    dc.tblUsers.Add(newuser);
                    dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Seed()
        {

            //Used to default some data

            User newuser = new User( 1, 1, "Parker", "Foord", "parker");
            Insert(newuser);

        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserId.ToString()))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserId == user.UserId);
                            if(tblUser != null)
                            {
                                // Check the password
                                if (tblUser.Password == GetHash(user.Password))
                                {

                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    user.Id = tblUser.Id;

                                    return true;


                                }
                                else
                                {
                                    throw new Exception("Cannot login with these credentials. Your IP has been saved");

                                }
                            }
                            else
                            {
                                throw new Exception("User id could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password not set");
                    }

                }
                else
                {
                    throw new Exception("UserName not set");

                }
            }
            
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
