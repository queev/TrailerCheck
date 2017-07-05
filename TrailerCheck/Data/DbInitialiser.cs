using TrailerCheck.Models;
using System;
using System.Linq;

namespace TrailerCheck.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(TrailerCheckContext context)
        {
            context.Database.EnsureCreated();

            // Look for any owners
            if (context.Owners.Any())
            {
                return;   // DB has been seeded
            }

            var owners = new Owner[]
            {
            new Owner{FirstName="Carson",LastName="Alexander",RegistrationDate=DateTime.Parse("2005-09-01")},
            new Owner{FirstName="Meredith",LastName="Alonso",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Owner{FirstName="Arturo",LastName="Anand",RegistrationDate=DateTime.Parse("2003-09-01")},
            new Owner{FirstName="Gytis",LastName="Barzdukas",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Owner{FirstName="Yan",LastName="Li",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Owner{FirstName="Peggy",LastName="Justice",RegistrationDate=DateTime.Parse("2001-09-01")},
            new Owner{FirstName="Laura",LastName="Norman",RegistrationDate=DateTime.Parse("2003-09-01")},
            new Owner{FirstName="Nino",LastName="Olivetto",RegistrationDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Owner o in owners)
            {
                context.Owners.Add(o);
            }
            context.SaveChanges();

            var trailers = new Trailer[]
            {
            new Trailer {SerialNumber="709652", ProductGroup="DP120", Description="DP120 12' x 6'6\" x 6' Deck Tank & Front Flap", YearOfManufacture="2017"},
            new Trailer {SerialNumber="709231", ProductGroup="P8e", Description="P8e 8'2\" x 4'9\" Ramp 750kg", YearOfManufacture="2017"},
            new Trailer {SerialNumber="5136308", ProductGroup="LM105", Description="LM105 10' x 5'6\" Resin with Dropsides 2700kg", YearOfManufacture="2017"},
            new Trailer {SerialNumber="5136306", ProductGroup="LM85", Description="LM85 8' x 5' Resin with Dropsides 2700kg", YearOfManufacture="2017"},
            new Trailer {SerialNumber="5136307", ProductGroup="LM85", Description="LM85 8' x 5' Resin with Dropsides 2700kg", YearOfManufacture="2017"},
            new Trailer {SerialNumber="710761", ProductGroup="CT166", Description="CT166 16' x 6'6\" Resin with Dropsides 3ft Ramp 3500kg", YearOfManufacture="2017"},
            new Trailer {SerialNumber="710530", ProductGroup="GP106", Description="GP106 10' x 5'10\" Resin Low Side 175 x 16", YearOfManufacture="2017"}
            };
            foreach (Trailer t in trailers)
            {
                context.Trailers.Add(t);
            }
            context.SaveChanges();

            var registrations = new Registration[]
            {
            new Registration{OwnerID=1, TrailerID=1},
            new Registration{OwnerID=1, TrailerID=2},
            new Registration{OwnerID=1, TrailerID=3},
            new Registration{OwnerID=2, TrailerID=4},
            new Registration{OwnerID=2, TrailerID=5},
            new Registration{OwnerID=2, TrailerID=6},
            new Registration{OwnerID=3, TrailerID=1},
            new Registration{OwnerID=4, TrailerID=1},
            new Registration{OwnerID=4, TrailerID=2},
            new Registration{OwnerID=5, TrailerID=4},
            new Registration{OwnerID=6, TrailerID=6},
            new Registration{OwnerID=7, TrailerID=7},
            };
            foreach (Registration r in registrations)
            {
                context.Registrations.Add(r);
            }
            context.SaveChanges();
        }
    }
}