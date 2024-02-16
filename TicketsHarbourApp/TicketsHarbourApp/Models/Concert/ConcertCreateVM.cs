using System.ComponentModel.DataAnnotations;
using TicketsHarbourApp.Models.Event;

namespace TicketsHarbourApp.Models.Concert
{
    public class ConcertCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Concert Name")]
        public string ConcertName { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [Display(Name = "Performers")]
        public string Performers { get; set; } = null!;


        [Required]
        [MaxLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

           
        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;




    }
}
