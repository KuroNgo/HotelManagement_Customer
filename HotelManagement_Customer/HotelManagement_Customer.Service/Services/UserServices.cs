using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using System.Collections.Generic;

namespace HotelManagement_Customer.Service
{
    public interface IUserServices
    {
        UserAccount Add(UserAccount userAccount);
        void Update(UserAccount userAccount);
        UserAccount Delete(int id);
        UserAccount GetById(int id);
        UserAccount GetByLoginName(string loginName);
        IEnumerable<UserAccount> GetAllAccounts();
        void ChangePassword(string email, string newPassword);
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

        public UserAccount Add(UserAccount userAccount)
        {
            return _userRepository.Add(userAccount);
        }

        public void Update(UserAccount userAccount)
        {
            _userRepository.UpdateUser(userAccount);
        }

        public UserAccount Delete(int id)
        {
            return _userRepository.Delete(id);
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

        public void ChangePassword(string email, string newPassword)
        {
            _userRepository.ChangePassword(email, newPassword);
            _unitOfWork.Commit();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        
    }
}
