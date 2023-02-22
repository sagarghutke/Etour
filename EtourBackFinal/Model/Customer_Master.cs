using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EtourBackFinal.Model
{
    public class Customer_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        [NotNull]
        public string? CustomerName { get; set; }

        [StringLength(10)]
        public string? UserName { get;set; }

        [EmailAddress]
        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required, NotNull]
        [MaxLength(15,ErrorMessage ="Length Can't exceed 15 Characters")]
        [MinLength(8,ErrorMessage ="Length Can't be less than 8 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Create_time { get; set; }

        public ICollection<Booking_Header>? BookingHeaders { get; set; }
    }
}
