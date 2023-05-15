namespace HotelManagement_Customer.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        // Create a new object of DbContext
        HotelManagement_Customer_DbContext dbContext;
        public HotelManagement_Customer_DbContext Init()
        {
            return dbContext ?? (dbContext = new HotelManagement_Customer_DbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
