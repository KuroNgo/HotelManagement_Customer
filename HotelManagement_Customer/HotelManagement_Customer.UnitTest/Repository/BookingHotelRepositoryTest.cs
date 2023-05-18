using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace HotelManagement_Customer.UnitTest.RepositoryTest
{
    // at the repository file, it is interacted with database
    [TestClass]
    public class BookingHotelRepositoryTest
    {
        IDbFactory _dbFactory;
        IBookingHotelRepository _bookingHotelRepository;
        IUnitOfWork _unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _bookingHotelRepository = new BookingHotelRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ClearTestData();
        }

        private void ClearTestData()
        {
            var allUsers = _bookingHotelRepository.GetAll();
            foreach (var user in allUsers)
            {
                _bookingHotelRepository.Delete(user);
            }
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void GetAll_BookingRepository()
        {
            //Arrange
            var result = _bookingHotelRepository.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);

        }

        //[TestMethod]
        //public void Create_BookingRepository()
        //{
        //    var bookingHotel = new BookingHotel
        //    {
        //        Price = 45000,
        //        CreateDate = DateTime.Now,
        //        PaymentDay = DateTime.Now,
        //        BookingDate = DateTime.Now,
        //        Status = 1,
        //        UserId = 1,
        //        HotelId = 1
        //    };

        //    var result = _bookingHotelRepository.Add(bookingHotel);
        //    _unitOfWork.Commit();

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(bookingHotel.Id, result.Id);
        //    _bookingHotelRepository.Delete(bookingHotel);
        //    _unitOfWork.Commit();
        //}

    }
}
