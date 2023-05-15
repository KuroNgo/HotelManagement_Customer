using HotelManagement_Customer.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_Customer.Model.Model
{
    [Table("BookingHotel")]
    public class BookingHotel : IEntity
    {
        [Key]
        //Set identity in database
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaymentDay { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeleteDate { get; set; }

        [Range(0, 1)]
        public int Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserAccount UserAccount { get; set; }

        [Required]
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual HotelDetail HotelDetail { get; set; }
    }
}
