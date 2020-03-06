using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL.Models;
using PF.DVDCentral.PL;

namespace PF.DVDCentral.BL
{
    public class MovieManager
    {
        public static int Insert(out int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie newrow = new tblMovie();

                    newrow.Description = description;
                    newrow.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;

                    dc.tblMovies.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Movie movie)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, movie.Description);
                movie.Id = id;
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
                    tblMovie updaterow = (from dt in dc.tblMovies
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

        public static int Update(Movie movie)
        {
            return Update(movie.Id, movie.Description);
        }
        public static int Delete(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie deleterow = (from dt in dc.tblMovies
                                           where dt.Id == id
                                           select dt).FirstOrDefault();

                    dc.tblMovies.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Movie> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Movie> movies = new List<Movie>();
                    foreach (tblMovie dt in dc.tblMovies)
                    {
                        movies.Add(new Movie
                        {
                            Id = dt.Id,
                            Description = dt.Description
                          });
                    }
                    return movies;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie row = (from dt in dc.tblMovies
                                     where dt.Id == id
                                     select dt).FirstOrDefault();

                    if (row != null)
                        return new Movie { Id = row.Id, Description = row.Description };
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