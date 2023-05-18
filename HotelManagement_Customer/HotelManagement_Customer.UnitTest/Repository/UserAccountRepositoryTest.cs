using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BCrypt;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;
using System.Data.Entity.Validation;

namespace HotelManagement_Customer.UnitTest.Repository
{
    [TestClass]
    public class UserAccountRepositoryTest
    {
        IDbFactory _dbFactory;
        IUserAccountRepository _userAccountRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _userAccountRepository = new UserAccountRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ClearTestData();
        }

        private void ClearTestData()
        {
            var allUsers = _userAccountRepository.GetAllUserAccounts();
            foreach (var user in allUsers)
            {
                _userAccountRepository.Delete(user);
            }
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void GetUserByEmail_UserAccountRepository()
        {
            string email = "johndoe@example.com";

            var user = new UserAccount
            {
                FullName = "John Doe",
                Gender = "Male",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                LoginName = "johndoe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "password",
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetUserByEmail(email);

            Assert.IsNotNull(result);
            Assert.AreEqual(email, result.Email);

            _userAccountRepository.DeleteUserById(result.Id);
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void AddUser_UserAccountRepository()
        {
            var user = new UserAccount
            {
                FullName = "John Doe",
                Gender = "Male",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                LoginName = "johndoe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "password",
                Status = 1
            };

            var result = _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);


            _userAccountRepository.DeleteUserById(result.Id);
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void UpdateUser_UserAccountRepository()
        {
            var user = new UserAccount
            {
                FullName = "John Doe",
                Gender = "Male",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                LoginName = "johndoe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "password",
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            user.FullName = "Jane Smith";
            _userAccountRepository.UpdateUser(user);
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetUserById(user.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(user.FullName, result.FullName);

            _userAccountRepository.DeleteUserById(result.Id);
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void DeleteUserByEmail_UserAccountRepository()
        {
            var user = new UserAccount
            {
                FullName = "John Doe",
                Gender = "Male",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                LoginName = "johndoe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "password",
                Status = 1
            };
            _userAccountRepository.AddUser(user);
            _unitOfWork.Commit();

            string userEmail = user.Email;

            _userAccountRepository.DeleteUserByEmail(userEmail);
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetUserByEmail(userEmail);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserById_UserAccountRepository()
        {
            var user = new UserAccount
            {
                FullName = "John Doe",
                Gender = "Male",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                LoginName = "johndoe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "password",
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            int userId = user.Id;

            var result = _userAccountRepository.GetUserById(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);

            _userAccountRepository.DeleteUserById(userId);
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void GetAllUserAccounts_UserAccountRepository()
        {
            var users = new List<UserAccount>
    {
        new UserAccount
        {
            FullName = "John Doe",
        Gender = "Male",
        Email = "johndoe@example.com",
        Phone = "1234567890",
        LoginName = "johndoe",
        DateOfBirth = new DateTime(1990, 1, 1),
        Password = "password",
        Status = 1
        },
        new UserAccount
        {
            FullName = "Jane",
        Gender = "Male",
        Email = "Jane@example.com",
        Phone = "1234567899",
        LoginName = "jane",
        DateOfBirth = new DateTime(1990, 1, 1),
        Password = "password",
        Status = 1
        }
    };
            foreach (var user in users)
            {
                _userAccountRepository.Add(user);
            }
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetAllUserAccounts().ToList();

            Assert.AreEqual(users.Count, result.Count);

            foreach (var user in users)
            {
                _userAccountRepository.DeleteUserByEmail(user.Email);
            }
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void ChangePasswordById_UserAccountRepository()
        {
            var user = new UserAccount
            {
                Email = "test@example.com",
                FullName = "John Doe",
                Gender = "Nam",
                LoginName = "johndoe",
                Password = "password",
                Phone = "0329245971",
                DateOfBirth = DateTime.Now,
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            int userId = user.Id;
            string newPassword = "newpassword";

            _userAccountRepository.ChangePassword(userId, newPassword);
            var result = _userAccountRepository.GetUserById(userId);

            Assert.IsNotNull(result);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(newPassword, result.Password));
        }

        [TestMethod]
        public void ChangePasswordByEmail_UserAccountRepository()
        {
            var user = new UserAccount
            {
                Email = "test@example.com",
                FullName = "John Doe",
                Gender = "Nam",
                LoginName = "johndoe",
                Password = "password",
                Phone = "0329245971",
                DateOfBirth = DateTime.Now,
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            string userEmail = user.Email;
            string newPassword = "newpassword";

            _userAccountRepository.ChangePassword(userEmail, newPassword);
            var result = _userAccountRepository.GetUserByEmail(userEmail);

            Assert.IsNotNull(result);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(newPassword, result.Password));
        }
    }
           
}

