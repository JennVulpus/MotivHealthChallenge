using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MotivHealthChallenge;
using MotivHealthChallenge.Controllers;
using MotivHealthChallenge.Data;
using Xunit;

namespace FavoriteAPI.Tests
{
    public class FavoriteControllerTests
    {
        

        [Fact]
        public async Task GetAllUsers_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.GetAllUsers();

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }


        [Fact]
        public async Task GetUser_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.GetUser(users[1].Username);

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetCount_Returns()
        {
            //Arrange - my vars

            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.GetCount();

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        [Fact]
        public async Task GetUnique_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.GetUnique();

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        [Fact]
        public async Task PostUser_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var favList = A.CollectionOfFake<Favorite>(3);
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.PostUser(users[1].Username, favList.ToList());

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        [Fact]
        public async Task PutUser_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var favList = A.CollectionOfFake<Favorite>(3);
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.PutUser(users[1].Username, favList.ToList());

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        [Fact]
        public async Task PatchUser_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var favList = A.CollectionOfFake<Favorite>(3);
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.PatchUser(users[1].Username, favList.ToList());

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        [Fact]
        public async Task DeleteUser_Returns()
        {
            //Arrange - my vars
            var users = GetTestUsers();
            var context = SetupContext(users);
            var repo = A.Fake<IDataRepository>();
            var controller = new FavoriteController(repo, context);

            //Act - excution of function

            var response = await controller.DeleteUser(users[1].Username);

            //Assert - Testing if it's correct
            Assert.NotNull(response);
        }
        private List<User> GetTestUsers()
        {
            //List<User> testUsers = new();
            //List<Favorite> favList1 = new() { new Favorite { Id = 1, Name = "Knives Out", UserId = 1 } };
            //List<Favorite> favList2 = new() { new Favorite { Id = 2, Name = "Fantastic Mr. Fox", UserId = 2 }, new Favorite { Id = 3, Name = "Hidden Figures", UserId = 2 } };
            //List<Favorite> favList3 = new() { new Favorite { Id = 4, Name = "Fantastic Mr. Fox", UserId = 3 }, new Favorite { Id = 5, Name = "A New Hope", UserId = 3 } };
            //testUsers.Add(new User { Id = 1, Username = "Rob", Favorites = favList1 });
            //testUsers.Add(new User { Id = 2, Username = "Fred", Favorites = favList2 });
            //testUsers.Add(new User { Id = 3, Username = "Georgia", Favorites = favList3 });
            return A.CollectionOfFake<User>(2).ToList();
        }
        private DataContext SetupContext(List<User> users)
        {

            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            var context = new DataContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Users.AddRange(users);
            context.SaveChangesAsync();
            return context;
        }
        
    }
}