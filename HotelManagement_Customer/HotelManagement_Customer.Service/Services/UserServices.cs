using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using System.Collections.Generic;

namespace HotelManagement_Customer.Service
{
    public interface IUserServices
    {
        void Add(UserAccount hotelDetail);
        void Update(UserAccount hotelDetail);
        void Delete(int id);
        UserAccount GetById(int id);
        UserAccount GetByLoginName(string loginName);
        IEnumerable<UserAccount> GetAllAccounts();
        void ChangePassword(int id, string newPassword);
        void SaveChanges();
    }
    public class UserServices : IUserServices
    {
        IUserAccountRepository _userRepository;
        IUnitOfWork _unitOfWork;

        public UserServices(IUserAccountRepository userAccountRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userAccountRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(UserAccount userAccount)
        {
            _userRepository.AddUser(userAccount);
        }

        public void Update(UserAccount userAccount)
        {
            _userRepository.UpdateUser(userAccount);
        }

        public void Delete(int id)
        {
            _userRepository.DeleteUserById(id);
        }

        public UserAccount GetById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public UserAccount GetByLoginName(string loginName)
        {
            return _userRepository.GetUserByLoginName(loginName);
        }

        public IEnumerable<UserAccount> GetAllAccounts()
        {
            return _userRepository.GetAllUserAccounts();
        }

        public void ChangePassword(int id, string newPassword)
        {
            _userRepository.ChangePassword(id, newPassword);
            _unitOfWork.Commit();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        
    }
}
