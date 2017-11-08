using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Monsters.Data.Entities;
using Monsters.Data.Entities.Account;
using Monsters.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Monsters.DataAccess.EntityFramework
{
    public class MonstersDbContext : DbContext
    {
        private IDbContextTransaction _dbContextTransaction;

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }

        /*public MonstersDbContext(DbContextOptions<MonstersDbContext> options) :base(options)
        {
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=Monsters_Dev; User ID=Monsters; Password=Monsters; Trusted_Connection=False;");
            //optionsBuilder.UseSqlServer(@"Server=localhost; Database=Monsters_Migrations; User ID=Monsters; Password=Monsters; Trusted_Connection=False;");
            //optionsBuilder.UseSqlServer(@"Server=igormalinovschii.database.windows.net; Database=Monsters_Migrations; User ID=igormalinovschii; Password=Monsters1; Trusted_Connection=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add entities under tracking
            modelBuilder.Entity<User>().AddEntityUnderTracking();
            modelBuilder.Entity<Country>().AddEntityUnderTracking();
            modelBuilder.Entity<UserAddress>().AddEntityUnderTracking();

            // make Role.Name unique
            modelBuilder.Entity<Role>().HasIndex(p => p.Name).IsUnique();

            // make User.UserName and User.Email unique
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.UserName).IsUnique();



            //modelBuilder.Entity<User>().HasOne(p => p.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<User>().HasOne(p => p.UpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<User>().HasOne(p => p.UserAddress).WithOne().OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<User>().F()

            //modelBuilder.Entity<User>().has


            //modelBuilder.Entity<Country>().HasOne(p => p.CreatedBy).WithMany().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Country>().HasOne(p => p.UpdatedBy).WithMany().OnDelete(DeleteBehavior.SetNull);

            //--modelBuilder.Entity<UserAddress>().HasOne(p => p.CreatedBy).WithOne(p => p.UserAddress).HasForeignKey<User>(p => p.UserAddressId);

            //modelBuilder.Entity<UserAddress>().Property(p => p.CreatedBy).IsRequired().oOnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<UserAddress>().HasOne(p => p.UpdatedBy).WithOne().OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<User>

            /*modelBuilder.Entity<User>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(m => m.CreatedById).OnDelete(false);
            modelBuilder.Entity<User>().HasOne(p => p.UpdatedBy).WithMany().HasForeignKey(m => m.UpdatedById).WillCascadeOnDelete(false);*/

        }
        
        public void BeginTransaction()
        {
            _dbContextTransaction = Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public void RollBackTransaction()
        {
            _dbContextTransaction.Rollback();
        }
    }

    internal static class EntityBuilderExtensions
    {
        public static void AddEntityUnderTracking<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : BaseTrackingEntity
        {
            entityTypeBuilder.HasOne(p => p.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(p => p.UpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}