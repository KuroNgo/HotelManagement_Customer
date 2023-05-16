using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;

namespace HotelManagement_Customer.Data.Repository
{
    public interface IBookingHotelRepository : IRepository<BookingHotel>
    {

    }
    public class BookingHotelRepository : RepositoryBase<BookingHotel>, IBookingHotelRepository
    {
        public BookingHotelRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
