using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public decimal Cost { get; set; }
        public int InStockQty { get; set; }

        public int RatingsId { get; set; }

        public int FormatId { get; set; }

        public int DirectorId { get; set; }

    }
}
