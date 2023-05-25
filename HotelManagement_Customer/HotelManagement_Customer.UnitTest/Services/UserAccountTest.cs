//using HotelManagement_Customer.Data.Infrastructure;
//using HotelManagement_Customer.Data.Repository;
//using HotelManagement_Customer.Model.Model;
//using HotelManagement_Customer.Service;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;

//namespace HotelManagement_Customer.UnitTest.Services
//{
//    [TestClass]
//    public class UserAccountTest

//    {
//        private Mock<IUserAccountRepository> _mockUserRepository;
//        private Mock<IUnitOfWork> _mockUnitOfWork;
//        private IUserServices _userServices;
//        private List<UserAccount> _usersList;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _mockUserRepository = new Mock<IUserAccountRepository>();
//            _mockUnitOfWork = new Mock<IUnitOfWork>();
//            _userServices = new UserServices(_mockUserRepository.Object, _mockUnitOfWork.Object);
//            _usersList = new List<UserAccount>()
//            {
//                new UserAccount(){Id = 1, FullName = "PPP", Gender = "Male",
//                    Email = "PPP@gmail.com", Phone = "09123456", LoginName = "PPP",
//                    DateOfBirth = new DateTime(2002, 6, 11), Password = "hahaha", Status = 1},
//                new UserAccount(){Id = 2, FullName = "VVV", Gender = "Male",
//                    Email = "VVV@gmail.com", Phone = "091234567", LoginName = "VVV",
//                    DateOfBirth = new DateTime(2002, 4, 10), Password = "hihihi", Status = 2},
//                new UserAccount(){Id = 3, FullName = "SSS", Gender = "Male",
//                    Email = "SSS@gmail.com", Phone = "0912345678", LoginName = "SSS",
//                    DateOfBirth = new DateTime(2002, 2, 20), Password = "huhuhu", Status = 3}
//            };
//        }

//        [TestMethod]
//        public void UserAccount_Service_GetAll()
//        {
//            _mockUserRepository.Setup(m=>m.GetAll(null)).Returns(_usersList);

//            var reusult = _userServices.GetAllAccounts() as List<UserAccount>;

//            Assert.IsNotNull(reusult);
//            Assert.AreEqual(3, reusult.Count);
//        }
//    }
//}
