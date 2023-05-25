using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using HotelManagement_Customer.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;

namespace HotelManagement_Customer.UnitTest.Services
{
    [TestClass]
    public class HotelDetailTest
    {
        private Mock<IHotelDetailRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IHotelServices _hotelServices;
        private List<HotelDetail> _hotelServicesList;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IHotelDetailRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _hotelServices=new HotelServices(_mockRepository.Object,_mockUnitOfWork.Object);
            _hotelServicesList = new List<HotelDetail>()
            {
                new HotelDetail(){Id=1, HotelName="HotelName1",OwnerManager="PPP",TotalNumberOfRooms=50,FeedBack = "Nice",
                    Star = 5, Description = "..", Address = "2PDTV",
                    OpenTime = DateTime.Now.AddHours(7), CloseTime = DateTime.Now.AddHours(23)},
                new HotelDetail(){Id=2, HotelName="HotelName1",OwnerManager="VVV",TotalNumberOfRooms=50,FeedBack = "Nice",
                    Star = 4, Description = "..", Address = "3PDTV",
                    OpenTime = DateTime.Now.AddHours(7), CloseTime = DateTime.Now.AddHours(23)},
                new HotelDetail(){Id=3, HotelName="HotelName1",OwnerManager="SSS",TotalNumberOfRooms=50,FeedBack = "Nice",
                    Star = 3, Description = "..", Address = "4PDTV",
                    OpenTime = DateTime.Now.AddHours(7), CloseTime = DateTime.Now.AddHours(23)}
            };
        }

        [TestMethod]
        public void HotelDetail_Service_GetAll()
        {
            _mockRepository.Setup(m=>m.GetAll(null)).Returns(_hotelServicesList);

            var reusult = _hotelServices.GetAllHotel() as List<HotelDetail>;

            Assert.IsNotNull(reusult);
            Assert.AreEqual(3, reusult.Count);
        }
        [TestMethod]
        public void HotelDetail_Service_Create()
        {
            HotelDetail hotelDetail = new HotelDetail();
            int Id = 1;
            hotelDetail.HotelName = "HotelName1";
            hotelDetail.OwnerManager = "PPP";
            hotelDetail.TotalNumberOfRooms = 50;
            hotelDetail.FeedBack = "Nice";
            hotelDetail.Star = 5;
            hotelDetail.Description = "...";
            hotelDetail.Address = "1PDTV";
            hotelDetail.OpenTime = DateTime.Now.AddHours(7);
            hotelDetail.CloseTime = DateTime.Now.AddHours(23);

            _mockRepository.Setup(m => m.Add(hotelDetail)).Returns((HotelDetail p) =>
            {
                p.Id = 1;
                return p;
            });

            var reusult=_hotelServices.Add(hotelDetail);

            Assert.IsNotNull(reusult);
            Assert.AreEqual(1, reusult.Id);
        }
    }
}
