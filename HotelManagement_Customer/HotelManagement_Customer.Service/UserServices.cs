using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Data.Repository;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;

namespace HotelManagement_Customer.Service
{
    public interface IUserService
    {
        void Add(UserAccount userAccount);
        void Update(UserAccount userAccount);
        void Delete(int id);
        IEnumerable<UserAccount> GetAllAccount();
        IEnumerable<UserAccount> GetAllFullName(string fullName);
        UserAccount GetById(int id);
        IEnumerable<UserAccount> GetAllGender(string gender);
        void SaveChanges();
    }
    public class UserServices : IUserService
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
            _userRepository.Add(userAccount);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<UserAccount> GetAllAccount()
        {
            return _userRepository.GetAll(new string[] { "" });
        }

        public IEnumerable<UserAccount> GetAllFullName(string fullName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> GetAllGender(string gender)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }
    }
}
