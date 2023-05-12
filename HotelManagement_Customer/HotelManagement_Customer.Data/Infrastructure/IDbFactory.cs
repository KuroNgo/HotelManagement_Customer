using System;

namespace HotelManagement_Customer.Data.Infrastructure
{
    // Object initialization interface
    public interface IDbFactory : IDisposable
    {
        HotelManagement_Customer_DbContext Init();
    }
}
