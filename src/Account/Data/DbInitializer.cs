using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Data
{
    public class DbInitializer
    {
        public static void Initialize(AccountContext context)
        {
            context.Database.EnsureCreated();
            // Look for any User.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            //
            var users = new User[]
            {
                new User{ Username = "mbetania", Password = "Pass123*", BirthDay = new DateTime(1980,01,05), Name = "Maria Betânia Silva" },
                new User{ Username = "wsilva", Password = "Pass123*", BirthDay = new DateTime(1975,01,05), Name = "William Silva" },
                new User{ Username = "lebaramos", Password = "Pass123*", BirthDay = new DateTime(1981,11,07), Name = "Letícia Batista Ramos" },
                new User{ Username = "mbatista", Password = "Pass123*", BirthDay = new DateTime(2016,03,24), Name = "Mateus Batista Costa" },
                new User{ Username = "valtersonramos", Password = "Pass123*", BirthDay = new DateTime(1965,10,06), Name = "Valterson Batista Ramos" },
                new User{ Username = "chcosta", Password = "Pass123*", BirthDay = new DateTime(1983,06,05), Name = "Carlos Henrique de Almeida Costa" },
                new User{ Username = "crisbatista", Password = "Pass123*", BirthDay = new DateTime(1980,01,05), Name = "Cristina Batista Ramos" }
            };
            context.User.AddRange(users);
            context.SaveChanges();
        }
    }
}
