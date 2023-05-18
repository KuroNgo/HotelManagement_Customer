using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System.Collections.Generic;

namespace HotelManagement_Customer.Data.Repository
{
    public interface IHotelDetailRepository : IRepository<HotelDetail>
    {
        HotelDetail GetHotelDetailById(int hotelId);
        IEnumerable<HotelDetail> GetAllHotelDetails();
        void AddHotelDetail(HotelDetail hotelDetail);
        void UpdateHotelDetail(HotelDetail hotelDetail);
        void DeleteHotelDetail(HotelDetail hotelDetail);
    }
    public class HotelDetailRepository : RepositoryBase<HotelDetail>, IHotelDetailRepository
    {
        // called inheritance constractor
        public HotelDetailRepository(IDbFactory bFactory) : base(bFactory)
        {

        }

        public HotelDetail GetHotelDetailById(int hotelId)
        {
            return GetSingleById(hotelId);
        }

        public IEnumerable<HotelDetail> GetAllHotelDetails()
        {
            return GetAll();
        }

        public void AddHotelDetail(HotelDetail hotelDetail)
        {
            Add(hotelDetail);
        }

        public void UpdateHotelDetail(HotelDetail hotelDetail)
        {
            Update(hotelDetail);
        }

        public void DeleteHotelDetail(HotelDetail hotelDetail)
        {
            Delete(hotelDetail);
        }
    }
}

