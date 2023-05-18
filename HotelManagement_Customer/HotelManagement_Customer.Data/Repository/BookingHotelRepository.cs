using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement_Customer.Data.Repository
{
    public interface IBookingHotelRepository : IRepository<BookingHotel>
    {
        BookingHotel GetBookingById(int id);
        BookingHotel GetBookingByCreateDay(DateTime createDate);
        BookingHotel GetBookingByPaymentDay(DateTime paymentDate);
        BookingHotel GetBookingByBookingDay(DateTime bookingDate);
        BookingHotel GetBookingByDeleteDay(DateTime deleteDate);
    }
    public class BookingHotelRepository : RepositoryBase<BookingHotel>, IBookingHotelRepository
    {
        public BookingHotelRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public BookingHotel GetBookingByBookingDay(DateTime bookingDate)
        {
            return dbContext.Set<BookingHotel>().FirstOrDefault(u => u.BookingDate == bookingDate);
        }

        public BookingHotel GetBookingByCreateDay(DateTime createDate)
        {
            return dbContext.Set<BookingHotel>().FirstOrDefault(u => u.CreateDate == createDate);

        }

        public BookingHotel GetBookingByDeleteDay(DateTime deleteDate)
        {
            return dbContext.Set<BookingHotel>().FirstOrDefault(u => u.DeleteDate == deleteDate);
        }

        public BookingHotel GetBookingById(int id)
        {
            return GetSingleById(id);
        }

        public BookingHotel GetBookingByPaymentDay(DateTime paymentDate)
        {
            return dbContext.Set<BookingHotel>().FirstOrDefault(u => u.PaymentDay == paymentDate);
        }

    }
}
