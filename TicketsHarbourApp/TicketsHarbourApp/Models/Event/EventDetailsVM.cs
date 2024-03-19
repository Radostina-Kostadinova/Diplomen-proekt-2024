using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Event
{
    public class EventDetailsVM
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
        [Display(Name = "Town")]
        public string Town { get; set; } = null!;

        [Required]
        [Display(Name = "Adress")]
        public string Adress { get; set; } = null!;

        [Required]
        [Display(Name = "Performers")]
        public string Performers { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;


        [Required]
        [Display(Name = "Beginning")]
        public string Beginning { get; set; } = null!;



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


        [Display(Name = "LocationUrl")]
        public string LocationUrl { get; set; } = null!;


    }
}
