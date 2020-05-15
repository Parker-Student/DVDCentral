using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.DVDCentral.BL;
using System.Web;


namespace PF.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase File { get; set; }

        public decimal Cost { get; set; }
        public int InStockQty { get; set; }

        public int RatingsId { get; set; }

        public int FormatId { get; set; }

        public int DirectorId { get; set; }

        public string Format { get; set; }
        public string Director { get; set; }

        public string Rating { get; set; }

    }
}
