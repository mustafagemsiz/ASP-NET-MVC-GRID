using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace MVC_GRID.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new Builder());
        }
    }

    public class Builder : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Country> countryList = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                Country country = new Country();
                country.Name = FakeData.PlaceData.GetCountry();
                countryList.Add(country);
                context.Countries.Add(country);
            }
            context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                User user = new User();
                user.Name = FakeData.NameData.GetFirstName();
                user.Surname = FakeData.NameData.GetSurname();
                user.Age = FakeData.NumberData.GetNumber(10,90);

                Random r = new Random();
                int value = r.Next(0, 10);
                user.Country = countryList[value];
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}