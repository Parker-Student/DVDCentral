using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.BL
{
    public class RatingManager
    {
        public static int Insert(string description)
        {
            return 0;
        }

        public static int Insert(Rating rating)
        {
            return Insert(rating.Description);

        }

        public static int Update( int id, string description)
        {
            return 0;
        }

        public static int Update (Rating rating)
        {
            return Update(rating.ID, rating.Description);
        }

        public static int Delete(int id)
        {
            return 0;
        }

        
        public static List<Rating> Load()
        {
            return new List<Rating>();
        }

        public static Rating LoadByID()
        {
            return new Rating();
        }
    }
}
