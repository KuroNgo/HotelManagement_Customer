namespace HotelManagement_Customer.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private HotelManagement_Customer_DbContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        // ?? is a operation null- coalescing in C#
        // return of operand left if not equal null, else
        public HotelManagement_Customer_DbContext DbContext
        {
            get { return _context ?? (_context = _dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
