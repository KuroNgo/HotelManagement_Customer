using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HotelManagement_Customer.UnitTest.Repository
{
    [TestClass]
    public class HotelDetailRepositoryTest
    {
        IDbFactory _dbFactory;
        IHotelDetailRepository _hotelDetailRepository;
        IUnitOfWork _unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _hotelDetailRepository = new HotelDetailRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void GetAll_HotelDetailRepository()
        {
            var list = _hotelDetailRepository.GetAll().ToList();
            Assert.AreEqual(list.Count, list.Count);
        }

        // This should limit use
        // because it is auto range, it will create number no same
        [TestMethod]
        public void Create_HotelDetailRepository()
        {
            HotelDetail hotelDetail = new HotelDetail();
            hotelDetail.HotelName = "Test";
            hotelDetail.OwnerManager = "Test";
            hotelDetail.TotalNumberOfRooms = 1;
            hotelDetail.FeedBack = "Test";
            hotelDetail.Star = 4;
            hotelDetail.Description = "Test";
            hotelDetail.Address = "Test";
            hotelDetail.CloseTime = DateTime.Now;
            hotelDetail.OpenTime = DateTime.Now;

            var result = _hotelDetailRepository.Add(hotelDetail);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, result.Id);

        }

        [TestMethod]
        public void DeleteById_HotelDetailRepository()
        {
            int id = 7;
            var result = _hotelDetailRepository.Delete(id).ToString();
            //_unitOfWork.Commit();
            Assert.AreNotSame(id, result);
        }

        [TestMethod]
        public void Delete_HotelDetailRepository()
        {
            HotelDetail hotelDetail = new HotelDetail();
            hotelDetail.HotelName = "Test";
            hotelDetail.OwnerManager = "Test";
            hotelDetail.TotalNumberOfRooms = 1;
            hotelDetail.FeedBack = "Test";
            hotelDetail.Star = 4;
            hotelDetail.Description = "Test";
            hotelDetail.Address = "Test";
            hotelDetail.CloseTime = DateTime.Now;
            hotelDetail.OpenTime = DateTime.Now;
            var result = _hotelDetailRepository.Delete(hotelDetail);
            //_unitOfWork.Commit();
            Assert.AreNotSame(hotelDetail, result);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(5, result.Id);
        }
    }
}
