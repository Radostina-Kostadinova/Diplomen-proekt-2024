using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Concert
{
    public class ConcertPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Concert")]
        public string Name { get; set; } = null!;
      


    }
}
