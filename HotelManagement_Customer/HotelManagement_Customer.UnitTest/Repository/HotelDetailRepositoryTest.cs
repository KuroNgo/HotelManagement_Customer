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

        [TestCleanup]
        public void Cleanup()
        {
            var hotelDetails = _hotelDetailRepository.GetAll().ToList();
            foreach (var hotelDetail in hotelDetails)
            {
                _hotelDetailRepository.Delete(hotelDetail);
            }
            _unitOfWork.Commit();
        }


        [TestMethod]
        public void GetAll_HotelDetailRepository()
        {
            var expectedCount = 1;
            var hotelDetail = new HotelDetail
            {
                HotelName = "Example Hotel",
                OwnerManager = "John Smith",
                TotalNumberOfRooms = 50,
                FeedBack = "Great hotel!",
                Star = 4.5,
                Description = "This is a luxurious hotel offering exceptional amenities and services.",
                Address = "123 Main Street, City",
                CloseTime = DateTime.Now.AddHours(23),
                OpenTime = DateTime.Now.AddHours(7)
            };

            _hotelDetailRepository.Add(hotelDetail);
            _unitOfWork.Commit();

            var hotelDetails = _hotelDetailRepository.GetAll().ToList();

            Assert.AreEqual(expectedCount, hotelDetails.Count);

            _hotelDetailRepository.Delete(hotelDetail);
            _unitOfWork.Commit();
        }


        [TestMethod]
        public void Create_HotelDetailRepository()
        {
            var hotelDetail = new HotelDetail
            {
                HotelName = "Example Hotel",
                OwnerManager = "John Smith",
                TotalNumberOfRooms = 50,
                FeedBack = "Great hotel!",
                Star = 4.5,
                Description = "This is a luxurious hotel offering exceptional amenities and services.",
                Address = "123 Main Street, City",
                CloseTime = DateTime.Now.AddHours(23),
                OpenTime = DateTime.Now.AddHours(7)
            };

            var result = _hotelDetailRepository.Add(hotelDetail);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(hotelDetail.Id, result.Id);
            _hotelDetailRepository.Delete(hotelDetail);
            _unitOfWork.Commit();
        }


        [TestMethod]
        public void DeleteById_HotelDetailRepository()
        {
            var hotelDetail = new HotelDetail
            {
                HotelName = "Example Hotel",
                OwnerManager = "John Smith",
                TotalNumberOfRooms = 50,
                FeedBack = "Great hotel!",
                Star = 4.5,
                Description = "This is a luxurious hotel offering exceptional amenities and services.",
                Address = "123 Main Street, City",
                CloseTime = DateTime.Now.AddHours(23),
                OpenTime = DateTime.Now.AddHours(7)
            };

            _hotelDetailRepository.AddHotelDetail(hotelDetail);
            _unitOfWork.Commit();

            var deletedHotelDetailId = hotelDetail.Id;
            _hotelDetailRepository.DeleteHotelDetail(hotelDetail);
            _unitOfWork.Commit();

            Assert.IsNull(_hotelDetailRepository.GetHotelDetailById(deletedHotelDetailId));
        }




        [TestMethod]
        public void Delete_HotelDetailRepository()
        {
            var hotelDetail = new HotelDetail
            {
                HotelName = "Example Hotel",
                OwnerManager = "John Smith",
                TotalNumberOfRooms = 50,
                FeedBack = "Great hotel!",
                Star = 4.5,
                Description = "This is a luxurious hotel offering exceptional amenities and services.",
                Address = "123 Main Street, City",
                CloseTime = DateTime.Now.AddHours(23),
                OpenTime = DateTime.Now.AddHours(7)
            };

            var createdHotelDetail = _hotelDetailRepository.Add(hotelDetail);
            _unitOfWork.Commit();

            var result = _hotelDetailRepository.Delete(createdHotelDetail);
            _unitOfWork.Commit();

            Assert.AreEqual(createdHotelDetail, result);
            Assert.IsNull(_hotelDetailRepository.GetSingleById(createdHotelDetail.Id));
        }

    }
}
