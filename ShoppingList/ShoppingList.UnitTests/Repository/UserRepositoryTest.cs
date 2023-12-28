using ShoppingList.DataAccess.Entities;
using ShoppingList.DataAccess;
using FluentAssertions;
using NUnit.Framework;

namespace ShoppingList.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
                new UserEntity()
                {
                    Name = "testName1",
                    Email = "testEmail1",
                    PasswordHash = "passwordTest1",
                    PhoneNumber = "phoneNumberTest1",
                    ExternalId = Guid.NewGuid()
                },
                new UserEntity()
                {
                    Name = "testName2",
                    Email = "testEmail2",
                    PasswordHash = "passwordTest2",
                    PhoneNumber = "phoneNumberTest2",
                    ExternalId = Guid.NewGuid()
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll();

            actualUsers.Should().BeEquivalentTo(users);
        }

        [Test]
        public void GetAllUsersWithFilterTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
                new UserEntity()
                {
                    Name = "testName1",
                    Email = "testEmail1",
                    PasswordHash = "passwordTest1",
                    PhoneNumber = "phoneNumberTest1",
                    ExternalId = Guid.NewGuid()
                },
                new UserEntity()
                {
                    Name = "testName2",
                    Email = "testEmail2",
                    PasswordHash = "passwordTest2",
                    PhoneNumber = "phoneNumberTest2",
                    ExternalId = Guid.NewGuid()
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Name == "testName1").ToArray();

            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Name == "testName1"));
        }

        [Test]
        public void SaveNewUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Name = "testName1",
                Email = "testEmail1",
                PasswordHash = "passwordTest1",
                PhoneNumber = "phoneNumberTest1",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Id)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));

            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Name = "testName1",
                Email = "testEmail1",
                PasswordHash = "passwordTest1",
                PhoneNumber = "phoneNumberTest1",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();


            user.Name = "newName";
            user.Email = "newEmail";
            user.PasswordHash = "newPassword";
            user.PhoneNumber = "newPhoneNumber";
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }

        [Test]
        public void DeleteUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Name = "testName1",
                Email = "testEmail1",
                PasswordHash = "passwordTest1",
                PhoneNumber = "phoneNumberTest1",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Delete(user);

            context.Users.Count().Should().Be(0);
        }

        [Test]
        public void GetByIdUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();
            var users = new UserEntity[]
            {
                new UserEntity()
                {
                    Name = "testName1",
                    Email = "testEmail1",
                    PasswordHash = "passwordTest1",
                    PhoneNumber = "phoneNumberTest1",
                    ExternalId = Guid.NewGuid()
                },
                new UserEntity()
                {
                    Name = "testName2",
                    Email = "testEmail2",
                    PasswordHash = "passwordTest2",
                    PhoneNumber = "phoneNumberTest2",
                    ExternalId = Guid.NewGuid()
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();


            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[0].Id);
            actualUser.Should().BeEquivalentTo(users[0]);


            actualUser = repository.GetById(users[users.Length - 1].Id + 10);
            actualUser.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}