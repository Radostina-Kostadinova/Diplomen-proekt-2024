using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Concert
{
    public class ConcertDetailsVM
    {
        [Key]
        public int Id { get; set; }

      
        [Display(Name = "Concert Name")]
        public string ConcertName { get; set; } = null!;

       
        [Display(Name = "Performers")]
        public string Performers { get; set; } = null!;

        [Display(Name = "Description")]
        public string Description { get; set; } = null!;


        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;

    }
}
