using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;
using System.Security.Cryptography;

namespace HotelManagement_Customer.Data.Repository
{
    // When Kuro write this code in RepositoryBase, We do not write code duplicate again
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        void AddUser(UserAccount userAccount);

        void UpdateUser(UserAccount userAccount);

        void DeleteUserById(int id);
        void DeleteUserByEmail(string email);

        UserAccount GetUserById(int id);

        UserAccount GetUserByLoginName(string loginName);

        IEnumerable<UserAccount> GetAllUserAccounts();

        void ChangePassword(string email, string newPassword);
        void ChangePassword(int id, string newPassword);
        UserAccount GetUserByEmail(string email);


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

        public void DeleteUserByEmail(string email)
        {
            var user = GetUserByEmail(email);
            if (user != null)
            {
                Delete(user);
            }
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

        public void ChangePassword(string email, string newPassword)
        {
            var user = GetUserByEmail(email);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                Update(user);
            }
        }

        public void ChangePassword(int id, string newPassword)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                Update(user);
            }
        }

        public UserAccount GetUserByEmail(string email)
        {
            return dbContext.Set<UserAccount>().FirstOrDefault(u => u.Email == email);
        }
    }
}
