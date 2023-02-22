using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtourBackFinal.Model
{
    public class Passenger_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="Length should be less than 10")]
        public string Passengertype { get; set; }

        [Required]
        public double PassengerAmount { get;set; }

        //[Required]  
        public int? BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking_Header? BookingHeader { get; set; }


    }
}
