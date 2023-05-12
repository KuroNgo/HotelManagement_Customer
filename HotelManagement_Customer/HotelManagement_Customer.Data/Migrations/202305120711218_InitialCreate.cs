namespace HotelManagement_Customer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingHotel",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Price = c.Double(nullable: false),
                    CreateDate = c.DateTime(nullable: false),
                    PaymentDay = c.DateTime(nullable: false),
                    BookingDate = c.DateTime(nullable: false),
                    DeleteDate = c.DateTime(nullable: false),
                    Status = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    HotelId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelDetail", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccount", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HotelId);

            CreateTable(
                "dbo.HotelDetail",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HotelName = c.String(nullable: false, maxLength: 100),
                    OwnerManager = c.String(nullable: false, maxLength: 250),
                    TotalNumberOfRooms = c.Int(nullable: false),
                    FeedBack = c.String(),
                    Star = c.Double(nullable: false),
                    Description = c.String(maxLength: 500),
                    Address = c.String(),
                    CloseTime = c.DateTime(nullable: false),
                    OpenTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserAccount",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FullName = c.String(nullable: false, maxLength: 250),
                    Gender = c.String(nullable: false, maxLength: 20),
                    Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    Phone = c.String(maxLength: 20, fixedLength: true, unicode: false),
                    LoginName = c.String(nullable: false, maxLength: 20, fixedLength: true, unicode: false),
                    DateOfBirth = c.DateTime(nullable: false),
                    Password = c.String(nullable: false, maxLength: 50, fixedLength: true, unicode: false),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.BookingHotel", "UserId", "dbo.UserAccount");
            DropForeignKey("dbo.BookingHotel", "HotelId", "dbo.HotelDetail");
            DropIndex("dbo.BookingHotel", new[] { "HotelId" });
            DropIndex("dbo.BookingHotel", new[] { "UserId" });
            DropTable("dbo.UserAccount");
            DropTable("dbo.HotelDetail");
            DropTable("dbo.BookingHotel");
        }
    }
}
