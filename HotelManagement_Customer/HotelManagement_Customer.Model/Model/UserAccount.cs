using HotelManagement_Customer.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_Customer.Model.Model
{
    [Table("UserAccount")]
    public class UserAccount : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string FullName { get; set; }

        [Required, MaxLength(20)]
        public string Gender { get; set; }

        [Column(TypeName = "varchar")]
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(20)]
        [Column(TypeName = "char")]
        public string LoginName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(50)]
        [Column(TypeName = "char")]
        public string Password { get; set; }

        [Range(0, 1)]
        [DefaultValue(1)]
        public int Status { get; set; }

        public virtual IEnumerable<BookingHotel> User { get; set; }

    }
}
