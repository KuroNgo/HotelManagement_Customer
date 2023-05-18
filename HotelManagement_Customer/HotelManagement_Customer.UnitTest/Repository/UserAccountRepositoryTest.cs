using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BCrypt;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void GetUserByEmail_UserAccountRepository()
        {
            string email = "test@example.com";

            var user = new UserAccount
            {
                Email = email,
                FullName = "John Doe",
                LoginName = "johndoe",
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
                Email = "test@example.com",
                FullName = "John Doe",
                LoginName = "johndoe",
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
                Email = "test@example.com",
                FullName = "John Doe",
                LoginName = "johndoe",
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
        public void DeleteUserById_UserAccountRepository()
        {
            var user = new UserAccount
            {
                Email = "test@example.com",
                FullName = "John Doe",
                LoginName = "johndoe",
                Password = "password",
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            int userId = user.Id;

            _userAccountRepository.DeleteUserById(userId);
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetUserById(userId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserById_UserAccountRepository()
        {
            var user = new UserAccount
            {
                Email = "test@example.com",
                FullName = "John Doe",
                LoginName = "johndoe",
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
            Email = "test1@example.com",
            FullName = "John Doe",
            LoginName = "johndoe",
            Password = "password",
            Status = 1
        },
        new UserAccount
        {
            Email = "test2@example.com",
            FullName = "Jane Smith",
            LoginName = "janesmith",
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
                _userAccountRepository.DeleteUserById(user.Id);
            }
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void ChangePassword_UserAccountRepository()
        {
            var user = new UserAccount
            {
                Email = "test@example.com",
                FullName = "John Doe",
                LoginName = "johndoe",
                Password = "password",
                Status = 1
            };
            _userAccountRepository.Add(user);
            _unitOfWork.Commit();

            int userId = user.Id;
            string newPassword = "newpassword";

            _userAccountRepository.ChangePassword(userId, newPassword);
            _unitOfWork.Commit();

            var result = _userAccountRepository.GetUserById(userId);

            Assert.IsNotNull(result);
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(newPassword, result.Password));

            _userAccountRepository.DeleteUserById(userId);
            _unitOfWork.Commit();
        }

    }
}
