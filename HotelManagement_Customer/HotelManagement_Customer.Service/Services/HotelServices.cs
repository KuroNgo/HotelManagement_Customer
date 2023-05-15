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
        void Add(HotelDetail hotelDetail);
        void Update(HotelDetail hotelDetail);
        void Delete(int id);
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
        public void Add(HotelDetail hotelDetail)
        {
            _HotelDetailRepository.Add(hotelDetail);
        }

        public void Delete(int id)
        {
            _HotelDetailRepository.Delete(id);
        }

        public IEnumerable<HotelDetail> GetAllHotel()
        {
            return _HotelDetailRepository.GetAll();
        }

        public HotelDetail GetById(int id)
        {
            return _HotelDetailRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(HotelDetail hotelDetail)
        {
            _HotelDetailRepository.Update(hotelDetail);
        }
    }
}
