using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtourBackFinal.Model
{
    public class Itnerary_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItneraryId { get; set; }

        [Required]
        public int NoOfDays { get; set; }

        [StringLength(200)]
        [Required]
        public string? Itnearydetails { get; set; }

        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public Category_Master? CategoryMaster { get; set; }
    }
}
