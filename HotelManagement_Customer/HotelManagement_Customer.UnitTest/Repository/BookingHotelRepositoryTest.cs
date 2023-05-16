using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HotelManagement_Customer.UnitTest.RepositoryTest
{
    // at the repository file, it is interacted with database
    [TestClass]
    class BookingHotelRepositoryTest
    {
        IDbFactory _dbFactory;
        IBookingHotelRepository _userAccountRepository;
        IUnitOfWork _unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _userAccountRepository = new BookingHotelRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void BookingRepository_GetAll()
        {
            //Arrange
            var list = _userAccountRepository.GetAll().ToList();

            //Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void BookingRepository_Create()
        {


        }
    }
}
