using System.Collections.Generic;
using System.Reflection.Emit;
using SubastasAPI.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SubastasAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<PujaEntity>()
            //       .HasOne(p => p.Product)  
            //       .WithMany()               
            //       .HasForeignKey(p => p.IdProduct) 
            //       .HasPrincipalKey(p => p.Id) 
            //       .OnDelete(DeleteBehavior.Cascade);
        }
        //Add models here
       
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<PujaEntity> Puja { get; set; }
        public DbSet<ProductEntity> Product { get; set; }

    }
}