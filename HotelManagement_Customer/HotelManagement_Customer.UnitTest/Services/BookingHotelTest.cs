using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using HotelManagement_Customer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace HotelManagement_Customer.UnitTest.ServicesTest
{
    [TestClass]
    public class BookingHotelTest
    {
        private Mock<IBookingHotelRepository> _mockBKHRepository;
        private Mock<IUnitOfWork> _mockUOfWork;
        private IBookingServices _mockBookingServices;
        private List<BookingHotel> _listBooks;

        [TestInitialize]
        public void Initialize()
        {
            _mockBKHRepository = new Mock<IBookingHotelRepository>();
            _mockUOfWork = new Mock<IUnitOfWork>();
            _mockBookingServices = new BookingServices(_mockBKHRepository.Object, _mockUOfWork.Object);
            _listBooks = new List<BookingHotel>()
            {
                new BookingHotel() 
                {
                    Id=1,Price=2000,CreateDate=DateTime.Now,
                    PaymentDay=DateTime.Now,BookingDate=DateTime.Now,
                    DeleteDate=DateTime.Now
                },
                new BookingHotel()
                {
                    Id=2,Price=3000,CreateDate=DateTime.Now,
                    PaymentDay=DateTime.Now,BookingDate=DateTime.Now,
                    DeleteDate=DateTime.Now
                },
                new BookingHotel()
                {
                    Id=3,Price=4000,CreateDate=DateTime.Now,
                    PaymentDay=DateTime.Now,BookingDate=DateTime.Now,
                    DeleteDate=DateTime.Now
                }
            };
        }

        [TestMethod]
        public void BKH_Service_GetAll()
        {
            _mockBKHRepository.Setup(m => m.GetAll(null)).Returns(_listBooks);

            var reusult = _mockBookingServices.GetAllGetAllByHotelDetail() as List<BookingHotel>;

            Assert.IsNotNull(reusult);
            Assert.AreEqual(3, reusult.Count);
        }
    }
}
