using Account.Controllers;
using Account.Models;
using Account.Models.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Account.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task ReturnsAViewResult_WithAListOfUsers()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetAll())
               .ReturnsAsync(GetTestUsers());
            var controller = new UsersController(mockRepo.Object, null);
            //
            // Act
            var result = await controller.Get();
        }

        private IEnumerable<User> GetTestUsers()
        {
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
            return users;
        }
    }
}
