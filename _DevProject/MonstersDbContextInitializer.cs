using Microsoft.EntityFrameworkCore;
using Monsters.Common;
using Monsters.Data.Entities;
using Monsters.Data.Entities.Account;
using Monsters.Data.Enums;
using Monsters.DataAccess.EntityFramework;
using System;
using System.Linq;

namespace _DevProject
{
    public static class MonstersDbContextInitializer
    {
        public static void Initialize(MonstersDbContext context)
        {
            // check pending migration, if there is something then migrate database and run seed method
            if (context.Database.GetPendingMigrations().Any())
            {
                // migrate database
                context.Database.Migrate();

                // run seed method
                Seed(context);
            }
        }

        private static void Seed(MonstersDbContext context)
        {
            var now = DateTime.UtcNow;

            // insert roles
            if (!context.Roles.Any())
            {
                // insert roles
                context.Roles.Add(new Role { Name = UserRoles.Administrator.GetDescription() });
                context.Roles.Add(new Role { Name = UserRoles.User.GetDescription() });

                // commit changes
                context.SaveChanges();
            }   

            // check if admin user exists
            if (!context.Users.Any(p => p.Role.UserRole == UserRoles.Administrator))
            {
                // insert countries
                context.Countries.Add(new Country
                {
                    Name = "Moldova, Republic of",
                    Code = "MD",
                    Created = now,
                    Updated = now,
                    CreatedById = 1,
                    UpdatedById = 1
                });

                // add admin user
                AddAdminUser(context, now);
            }
        }

        private static void AddAdminUser(MonstersDbContext context, DateTime now)
        {
            // insert address
            context.UserAddress.Add(new UserAddress
            {
                Created = now,
                Updated = now,
                City = "City",
                Address = "Address",
                PostCode = "PostCode",
                Town = "Town",
                CountryId = 1,
                CreatedById = 1,
                UpdatedById = 1
            });


            // create administrator user
            context.Users.Add(new User
            {
                Enabled = true,
                Created = now,
                Updated = now,
                CreatedById = 1,
                UpdatedById = 1,
                UserRole = UserRoles.Administrator,
                UserName = "Administrator",
                FirstName = "Administrator",
                LastName = "Administrator",
                Password = "Password",
                Email = "Administrator@asd.md",
                UserAddressId = 1,
            });
            
            // disable constraints to insert first user
            context.Database.ExecuteSqlCommand("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");

            // commit to database
            context.SaveChanges();

            // enable constraints
            context.Database.ExecuteSqlCommand("EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
        }
    }
}