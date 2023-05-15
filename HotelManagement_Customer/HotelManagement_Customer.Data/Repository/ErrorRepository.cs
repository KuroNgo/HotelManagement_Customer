using HotelManagement_Customer.Data.Infrastructure;
using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_Customer.Data.Repository
{
    public interface IErrorRepository : IRepository<Error>
    {

    }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        protected ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
