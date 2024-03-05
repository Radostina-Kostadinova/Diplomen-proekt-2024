using System.ComponentModel.DataAnnotations;
using TicketsHarbourApp.Models.Concert;
using TicketsHarbourApp.Models.Location;

namespace TicketsHarbourApp.Models.Event
{
    public class EventIndexVM
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Concert")]
        public int ConcertId { get; set; }
        public string ConcertName { get; set; } = null!;


        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;



        [Required]
        [Display(Name = "Beginning")]
        public string Beginning { get; set; }



        [Range(0, 300)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }



        [Range(0, 5000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        [Range(0, 99)]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }


        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;





    }
}
