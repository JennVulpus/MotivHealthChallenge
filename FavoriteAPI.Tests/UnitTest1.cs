using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotivHealthChallenge;
using MotivHealthChallenge.Controllers;
using MotivHealthChallenge.Data;
using Xunit;

namespace FavoriteAPI.Tests
{
    public class FavoriteControllerTests
    {
        [Fact]
        public async Task GetAllUsers_ReturnsOk()
        {
            //Arrange - my vars
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;

            var context = new DataContext(options);
            var testUsers = GetTestUsers();
            var controller = new FavoriteController(context);
            //Act - excution of function

            var response = await controller.GetAllUsers();
      
            //Assert - Testing if it's correct
            Assert.Null(response.Value);
        }
        
        private List<User> GetTestUsers()
        {
            List<User> testUsers = new();
            List<Favorite> favList1 = new() { new Favorite { Id = 1, Name = "Knives Out", UserId = 1 } };
            List<Favorite> favList2 = new() { new Favorite { Id = 2, Name = "Fantastic Mr. Fox", UserId = 2 }, new Favorite { Id = 3, Name = "Hidden Figures", UserId = 2 } };
            List<Favorite> favList3 = new() { new Favorite { Id = 4, Name = "Fantastic Mr. Fox", UserId = 3 }, new Favorite { Id = 5, Name = "A New Hope", UserId = 3 } };
            testUsers.Add(new User { Id = 1, Username = "Rob", Favorites = favList1 });
            testUsers.Add(new User { Id = 2, Username = "Fred", Favorites = favList2 });
            testUsers.Add(new User { Id = 3, Username = "Georgia", Favorites = favList3 });
            return testUsers;
        }

    }
}