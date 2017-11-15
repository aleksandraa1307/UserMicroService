using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;


namespace UserMicroService.Tests
{
    public class UserTest
    {
        public void ClearUsers()
        {
            UserDB.listOfUsers.Clear();
        }

        [Test]
        public void Create_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);
            
            
        }
        [Test]
        public void Create_User_Fail()
        {
            ClearUsers();
            User testUser1 = new User
            {
                Id = 1,
                Name = "Ana"
            };
            User testUser2 = new User
            {
                Id = 1,
                Name = "Maja"
            };
            UserDB.AddUser(testUser1);
            UserDB.AddUser(testUser2);
            Assert.AreEqual(2, UserDB.listOfUsers.Count);
        }

        [Test]
        public void GetUserById_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserById(1));
        }

        [Test]
        public void GetUserById_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserById(2));
        }

        [Test]
        public void GetUserByName_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Sara"
            };
            UserDB.AddUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserByName("Sara"));
        }

        [Test]
        public void GetUserByName_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserByName("Pera"));
        }

        [Test]
        public void Get_All_Users_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            Assert.AreEqual(1, UserDB.GetAllUsers().Count);
        }

        [Test]
        public void EditUser_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Maja"
            };

            UserDB.EditUser(testUser1);

            Assert.AreEqual(testUser, UserDB.GetUserByName("Maja"));
        }

        [Test]
        public void EditUser_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Maja"
            };

            UserDB.EditUser(testUser1);

            Assert.AreEqual(null, UserDB.GetUserByName("Ana"));
        }

        [Test]
        public void Delete_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);
            UserDB.DeleteUser(1);

            Assert.AreEqual(0, UserDB.listOfUsers.Count);
        }

        [Test]
        public void Delete_User_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Ana"
            };
            UserDB.AddUser(testUser);
            UserDB.DeleteUser(2);

            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }

    }
}
