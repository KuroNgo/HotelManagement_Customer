using HotelManagement_Customer.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_Customer.Data
{
    public class HotelManagement_Customer_DbContext : DbContext
    {
        public HotelManagement_Customer_DbContext() : base("HotelManagementConnection")
        {
            //When we load the parent table, the subtable is not included
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BookingHotel> BookingHotels { get; set; }
        public DbSet<HotelDetail> HotelDetail { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
