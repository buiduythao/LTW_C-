using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class BuiDuyThaoContext : DbContext
    {
        public BuiDuyThaoContext()
            : base("name=BuiDuyThaoContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Ad_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Ad_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cus_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cus_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cus_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cus_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cus_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Ord_TotalMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Pro_Img)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Pro_Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Pro_Description)
                .IsUnicode(false);
        }
    }
}
