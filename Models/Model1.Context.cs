//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IceCreamProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class icecreamprojectEntities9 : DbContext
    {
        public icecreamprojectEntities9()
            : base("name=icecreamprojectEntities9")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_book> tbl_book { get; set; }
        public virtual DbSet<tbl_feedback> tbl_feedback { get; set; }
        public virtual DbSet<tbl_flavour> tbl_flavour { get; set; }
        public virtual DbSet<TBL_MEMBERSHIP> TBL_MEMBERSHIP { get; set; }
        public virtual DbSet<tbl_order> tbl_order { get; set; }
        public virtual DbSet<tbl_recipe> tbl_recipe { get; set; }
        public virtual DbSet<TBL_USER> TBL_USER { get; set; }
    }
}
