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
    public interface IHotelServices
    {
        HotelDetail Add(HotelDetail hotelDetail);
        void Update(HotelDetail hotelDetail);
        HotelDetail Delete(int id);
        IEnumerable<HotelDetail> GetAllHotel();
        HotelDetail GetById(int id);
        void SaveChanges();
    }
    public class HotelServices : IHotelServices
    {
        IHotelDetailRepository _HotelDetailRepository;
        IUnitOfWork _unitOfWork;

        public HotelServices(IHotelDetailRepository hotelDetailRepository, IUnitOfWork unitOfWork)
        {
            this._HotelDetailRepository = hotelDetailRepository;
            this._unitOfWork = unitOfWork;
        }
        public HotelDetail Add(HotelDetail hotelDetail)
        {
            return _HotelDetailRepository.Add(hotelDetail);
        }

        public HotelDetail Delete(int id)
        {
            return _HotelDetailRepository.Delete(id);
        }

        public IEnumerable<HotelDetail> GetAllHotel()
        {
            return _HotelDetailRepository.GetAll();
        }

        public HotelDetail GetById(int id)
        {
            return _HotelDetailRepository.GetSingleById(id);
        }

        public void Update(HotelDetail hotelDetail)
        {
            _HotelDetailRepository.Update(hotelDetail);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        
    }
}
