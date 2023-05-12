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
    public interface IBookingServices
    {
        void Add(BookingHotel bookingHotel);
        void Update(BookingHotel bookingHotel);
        void Delete(int id);
        void Remove(int id);
        IEnumerable<BookingHotel> GetAll();
        BookingHotel GetById(int id);

    }
    public class BookingServices : IBookingServices
    {
        IBookingHotelRepository _bookingHotelRepository;
        IUnitOfWork _unitOfWork;

        public void Add(BookingHotel bookingHotel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingHotel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookingHotel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookingHotel bookingHotel)
        {
            throw new NotImplementedException();
        }
    }
}
