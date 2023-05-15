using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;

namespace HotelManagement_Customer.Data.Repository
{
    public interface IHotelDetailRepository : IRepository<HotelDetail>
    {

    }
    public class HotelDetailRepository : RepositoryBase<HotelDetail>, IHotelDetailRepository
    {
        // called inheritance constractor
        public HotelDetailRepository(IDbFactory bFactory) : base(bFactory)
        {

        }
    }
}
