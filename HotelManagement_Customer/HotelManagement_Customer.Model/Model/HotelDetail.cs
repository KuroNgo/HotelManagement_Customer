using HotelManagement_Customer.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_Customer.Model.Model
{
    [Table("HotelDetail")]
    public class HotelDetail : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string HotelName { get; set; }

        [Required, MaxLength(250)]
        public string OwnerManager { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int TotalNumberOfRooms { get; set; }
        public string FeedBack { get; set; }

        [DefaultValue(5)]
        [Range(0, 5)]
        public double Star { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime CloseTime { get; set; }

        public DateTime OpenTime { get; set; }

        public virtual IEnumerable<BookingHotel> Hotel { get; set; }
    }
}
