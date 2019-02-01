using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace DAL
{
    public class EntityContext : DbContext
    {
        public System.Data.Entity.DbSet<Staff> Staffs { get; set; }
        //public System.Data.Entity.DbSet<Subject> Subjetcs { get; set; }
        public EntityContext() : base("DBConnection")
        { }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().Property(b => b.id).ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Staff>().Property(b => b.first_name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Staff>().Property(b => b.last_name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Staff>().Property(b => b.father_name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Staff>().Property(b => b.birth_dt).IsRequired();
            modelBuilder.Entity<Staff>().Property(b => b.email).HasMaxLength(50);
            modelBuilder.Entity<Staff>().Property(b => b.phone_nbr).HasMaxLength(13).IsRequired();

            //modelBuilder.Entity<Subject>().Property(b => b.id).ValueGeneratedOnAdd().IsRequired();
            //modelBuilder.Entity<Subject>().Property(b => b.name).HasMaxLength(20).IsRequired();
            //modelBuilder.Entity<Subject>().Property(b => b.Staffer).HasMaxLength(41).IsRequired();
        }
    }
}