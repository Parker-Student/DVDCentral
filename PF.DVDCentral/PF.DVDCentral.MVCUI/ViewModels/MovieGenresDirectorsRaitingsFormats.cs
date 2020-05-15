using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;


namespace PF.DVDCentral.MVCUI.ViewModels
{
    public class MovieGenresDirectorsRaitingsFormats
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Format> Formats { get; set; }
        public HttpPostedFileBase File { get; set; }


    }
}