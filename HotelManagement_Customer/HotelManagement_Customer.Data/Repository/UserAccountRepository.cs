using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HotelManagement_Customer.Data.Repository
{
    // When Kuro write this code in RepositoryBase, We do not write code duplicate again
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        void AddUser(UserAccount userAccount);

        void UpdateUser(UserAccount userAccount);

        void DeleteUserById(int id);

        UserAccount GetUserById(int id);
        UserAccount GetUserByLoginName(string loginName);

        IEnumerable<UserAccount> GetAllUserAccounts();

    }
    public class UserAccountRepository : RepositoryBase<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public void AddUser(UserAccount userAccount)
        {
            Add(userAccount);
        }

        public void UpdateUser(UserAccount userAccount)
        {
            Update(userAccount);
        }

        public void DeleteUserById(int id)
        {
            Delete(id);
        }

        public UserAccount GetUserById(int id)
        {
            return GetSingleById(id);
        }

        public UserAccount GetUserByLoginName(string loginName)
        {
            return dbContext.Set<UserAccount>().FirstOrDefault(u => u.LoginName == loginName);
        }

        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return GetAll();
        }
    }
}
