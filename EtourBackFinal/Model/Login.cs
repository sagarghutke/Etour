using System.ComponentModel.DataAnnotations;

namespace EtourBackFinal.Model
{
    public class Login
    {
        public int LoginId { get; set; }

        
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(15)]
        public string Password { get; set; }

    }
}
