﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DVDCentralEntities : DbContext
    {
        public DVDCentralEntities()
            : base("name=DVDCentralEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblDirector> tblDirectors { get; set; }
        public virtual DbSet<tblFormat> tblFormats { get; set; }
        public virtual DbSet<tblGenre> tblGenres { get; set; }
        public virtual DbSet<tblMovie> tblMovies { get; set; }
        public virtual DbSet<tblMovieGenre> tblMovieGenres { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderItem> tblOrderItems { get; set; }
        public virtual DbSet<tblRating> tblRatings { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
