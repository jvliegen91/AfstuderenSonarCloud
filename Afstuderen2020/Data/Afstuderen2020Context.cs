using Afstuderen2020.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Afstuderen2020.Data
{
    public class Afstuderen2020Context : DbContext
    {
        public Afstuderen2020Context(DbContextOptions<Afstuderen2020Context> options): base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Eigenschappen van de users.
            modelBuilder.Entity<User>()
                .Property(p => p.UserName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Address)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.HouseNumber)
                .HasMaxLength(6);

            modelBuilder.Entity<User>()
                .Property(p => p.HouseNumberAddition)
                .HasMaxLength(1);

            modelBuilder.Entity<User>()
                .Property(p => p.Residence)
                .HasMaxLength(50);
            
            modelBuilder.Entity<User>()
            .Property(p => p.PhoneNumber)
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
            .Property(p => p.Email)
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.PictureId)
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(p => p.Role)
                .HasMaxLength(25)
                .IsRequired();

            //Eigenschappen van de comments.
            modelBuilder.Entity<Comment>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(p => p.Message)
                .IsRequired();
        }
    }
}
