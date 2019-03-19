using System;
using System.Linq;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (context.Owners.Any())
            {
                return;
            }

            var owners = new Owner[]
            {
                new Owner { FirstName = "Xavier", Name = "RONDALLE", DateCreation = DateTime.Parse("2018-05-14 00:00:00.0000000"), DateEdition = DateTime.Parse("2018-05-14 00:00:00.0000000") },
                new Owner { FirstName = "Rinah", Name = "DOVES", DateCreation = DateTime.Parse("2018-05-14 00:00:00.0000000"), DateEdition = DateTime.Parse("2018-05-14 00:00:00.0000000") },
            };
            foreach (Owner o in owners)
            {
                context.Owners.Add(o);
            }
            context.SaveChanges();

            if (context.Apartments.Any())
            {
                return;   // DB has been seeded
            }

            var apartments = new Apartment[]
            {
                new Apartment { ApartmentName = "F5 Villa Blindée", ApartmentNumber = 344, DateCreation = DateTime.Parse("2018-05-14 00:00:00.0000000"), DateEdition = DateTime.Parse("2018-05-14 00:00:00.0000000"), OwnerID = owners.FirstOrDefault(o => o.Name == "RONDALLE").ID },
                new Apartment { ApartmentName = "Configuration Aplatti", ApartmentNumber = 210, DateCreation = DateTime.Parse("2018-05-14 00:00:00.0000000"), DateEdition = DateTime.Parse("2018-05-14 00:00:00.0000000"), OwnerID = owners.FirstOrDefault(o => o.Name == "RONDALLE").ID },
                new Apartment { ApartmentName = "Villa Basse", ApartmentNumber = 1125, DateCreation = DateTime.Parse("2018-05-14 00:00:00.0000000"), DateEdition = DateTime.Parse("2018-05-14 00:00:00.0000000"), OwnerID = owners.FirstOrDefault(o => o.Name == "DOVES").ID },
            };
            foreach (Apartment s in apartments)
            {
                context.Apartments.Add(s);
            }
            context.SaveChanges();
        }
    }
}