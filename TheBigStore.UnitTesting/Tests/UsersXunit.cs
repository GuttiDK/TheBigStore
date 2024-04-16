using TheBigStore.Repository.Repositories.UserRepositories;
using TheBigStore.Service.Services.UserServices;

namespace TheBigStore.UnitTesting.Tests
{
    public class UsersXunit
    {
        [Fact]
        public async Task TestCreateUserAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };

            //Act

            await _service.CreateAsync(entity);

            //Assert
            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);
        }

        [Fact]
        public async Task TestGetAllUsersAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };
            await _service.CreateAsync(entity);

            //Act

            var actualCustomer = await _service.GetAllAsync();

            //Assert

            Assert.NotNull(actualCustomer);
        }

        [Fact]
        public async Task TestGetUserByIdAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };
            await _service.CreateAsync(entity);

            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);

            //Act

            var user = await _service.GetById(actualCustomer.Id);

            //Assert

            Assert.NotNull(user);
        }

        [Fact]
        public async Task TestCheckUserAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };
            await _service.CreateAsync(entity);

            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);

            //Act

            var user = await _service.CheckUserAsync(actualCustomer.UserName);

            //Assert

            Assert.True(user);
        }

        [Fact]
        public async Task TestCheckAdminAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", RoleId = 1 };
            await _service.CreateAsync(entity);

            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);

            //Act

            var user = await _service.CheckAdminAsync(actualCustomer.Id);

            //Assert

            Assert.True(user);
        }

        [Fact]
        public async Task TestGetUserAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };
            await _service.CreateAsync(entity);

            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);

            //Act

            var user = await _service.GetUserAsync(actualCustomer.UserName, actualCustomer.Password);

            //Assert

            Assert.NotNull(user);
        }

        [Fact]
        public async Task TestGetUserAsyncNull()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new UserService(new MappingService(), new UserRepository(_context));

            //Arrange

            UserDto entity = new UserDto { UserName = "Test", Password = "Test", Email = "Test", };
            await _service.CreateAsync(entity);

            var actualCustomer = _context.Users.ToList().Last();

            Assert.Equal(entity.UserName, actualCustomer.UserName);
            Assert.Equal(entity.Password, actualCustomer.Password);

            //Act

            var user = await _service.GetUserAsync("Test2", "Test2");

            //Assert

            Assert.Null(user);
        }
    }
}
