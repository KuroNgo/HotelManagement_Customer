using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement_Customer.Data.Repository
{
    // When Kuro write this code in RepositoryBase, We do not write code duplicate again
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        // Return 
        IEnumerable<UserAccount> GetByFullName(string fullName);
    }
    public class UserAccountRepository : RepositoryBase<UserAccount>, IUserAccountRepository
    {
        // auto conjection when create this repository
        public UserAccountRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<UserAccount> GetByFullName(string fullName)
        {
            return this.dbContext.UserAccounts.Where(name => name.FullName == fullName);
        }
    }
}
