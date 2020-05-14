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
        public static int Insert(out int id, string description, string imagepath, int formatid, decimal cost, int instockqty, int directorid, string title, int ratingsid )
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie newrow = new tblMovie();

                    newrow.Description = description;
                    newrow.Title = title;
                    newrow.Cost = cost;
                    newrow.RaitingsId = ratingsid;
                    newrow.FormatId = formatid;
                    newrow.ImagePath = imagepath;
                    newrow.InStockQty = instockqty;
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
                int result = Insert(out id, movie.Description, movie.ImagePath, movie.FormatId, movie.Cost, movie.InStockQty, movie.DirectorId, movie.Title, movie.RatingsId );
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
                    List<Movie> results = new List<Movie>();
                   
                    var movies = (from m in dc.tblMovies
                                    join r in dc.tblRatings on m.RaitingsId equals r.Id
                                    join d in dc.tblDirectors on m.DirectorId equals d.Id
                                    join f in dc.tblFormats on m.FormatId equals f.Id
                                    orderby m.Title
                                    select new
                                    {
                                        m.Id,
                                        m.Title,
                                        m.ImagePath,
                                        m.Cost,
                                        m.InStockQty,
                                        Rating = r.Description,
                                        Format = f.Description,
                                        Director = d.FirstName + " " + d.LastName
                                    }).ToList();

                    movies.ForEach(pdt => results.Add(new Movie
                    {

                        Id = pdt.Id,
                        Title = pdt.Title,
                        ImagePath = pdt.ImagePath,
                        Cost = pdt.Cost,
                        InStockQty = pdt.InStockQty,
                        Rating = pdt.Rating,
                        Format = pdt.Format,
                        Director = pdt.Director
                    }));

                    return results;
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
                    var pdt = (from m in dc.tblMovies
                                  join r in dc.tblRatings on m.RaitingsId equals r.Id
                                  join d in dc.tblDirectors on m.DirectorId equals d.Id
                                  join f in dc.tblFormats on m.FormatId equals f.Id
                                  where m.Id == id
                                  select new
                                  {
                                      m.Id,
                                      m.Title,
                                      m.ImagePath,
                                      m.Cost,
                                      m.InStockQty,
                                      Rating = r.Description,
                                      Format = f.Description,
                                      Director = d.FirstName + " " + d.LastName
                                  }).FirstOrDefault();
                    if (pdt != null)
                    {
                        Movie movie = new Movie
                        {
                            Id = pdt.Id,
                            Title = pdt.Title,
                            ImagePath = pdt.ImagePath,
                            Cost = pdt.Cost,
                            InStockQty = pdt.InStockQty,
                            Rating = pdt.Rating,
                            Format = pdt.Format,
                            Director = pdt.Director
                        };
                        return movie;

                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}