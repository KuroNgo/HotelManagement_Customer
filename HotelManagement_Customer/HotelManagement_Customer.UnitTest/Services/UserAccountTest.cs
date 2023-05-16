using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagement_Customer.UnitTest.Services
{
    [TestClass]
    class UserAccountTest

    {
        IDbFactory dbFactory;
        IUserAccountRepository _userAccountRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            _userAccountRepository = new UserAccountRepository(dbFactory);
            _unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void UserAccountRepository_GetAll()
        {
            var list = _userAccountRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void UserAccountRepository_GetById()
        {
            int id = 1;
            var user = _userAccountRepository.GetSingleById(id).ToString();
            Assert.AreEqual(id, int.Parse(user));
        }

        //[TestMethod]
        //public void UserAccountRepository_Update()
        //{
        //    var user =
        //}
    }
}
