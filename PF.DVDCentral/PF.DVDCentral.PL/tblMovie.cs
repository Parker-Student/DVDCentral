//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PF.DVDCentral.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Cost { get; set; }
        public int RaitingsId { get; set; }
        public int FormatId { get; set; }
        public int DirectorId { get; set; }
        public int InStockQty { get; set; }
    }
}
