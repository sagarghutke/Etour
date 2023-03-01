using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        /*[Required]
        [StringLength(10,ErrorMessage ="Length should be less than 10")]
        public string Passengertype { get; set; }*/

        [Required,NotNull]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required]
        public double PassengerCost { get; set; }

        public int? CustomerId { get; set; }    

        [ForeignKey("CustomerId")]
        public Customer_Master? Customer { get; set; }

        public DateTime? DepartureDate { get; set; }


        public string? PassengerType { get; set; }



/*
        //[Required]  
        public int? BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking_Header? BookingHeader { get; set; }
*/

    }
}
