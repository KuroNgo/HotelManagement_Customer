using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_Customer.Service
{
    // When you call API, the interface is called
    public interface IBookingServices
    {
        BookingHotel Add(BookingHotel bookingHotel);
        void Update(BookingHotel bookingHotel);
        BookingHotel Delete(int id);
        IEnumerable<BookingHotel> GetAllGetAllByHotelDetail();
        IEnumerable<BookingHotel> GetAllGetAllByUserAccount();
        BookingHotel GetById(int id);
        void SaveChanges();
    }
    public class BookingServices : IBookingServices
    {
        IBookingHotelRepository _bookingHotelRepository;
        IUnitOfWork _unitOfWork;
        public BookingServices(IBookingHotelRepository bookingHotelRepository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._bookingHotelRepository = bookingHotelRepository;
        }
        public BookingHotel Add(BookingHotel bookingHotel)
        {
            return _bookingHotelRepository.Add(bookingHotel);
        }

        public BookingHotel Delete(int id)
        {
            return _bookingHotelRepository.Delete(id);
        }

        public IEnumerable<BookingHotel> GetAllGetAllByUserAccount()
        {
            return _bookingHotelRepository.GetAll(new string[] { "UserAccount" });
        }
        public IEnumerable<BookingHotel> GetAllGetAllByHotelDetail()
        {
            return _bookingHotelRepository.GetAll(new string[] { "HotelDetail" });
        }
        public BookingHotel GetById(int id)
        {
            return _bookingHotelRepository.GetSingleById(id);
        }

        public void Update(BookingHotel bookingHotel)
        {
            _bookingHotelRepository.Update(bookingHotel);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
