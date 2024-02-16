using System.ComponentModel.DataAnnotations;
using TicketsHarbourApp.Models.Event;

namespace TicketsHarbourApp.Models.Concert
{
    public class ConcertIndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ConcertName")]
        public string ConcertName { get; set; } = null!;
                
        [Display(Name = "Performers")]
        public string Performers { get; set; } = null!;

        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

             
        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;


       

    }
}
