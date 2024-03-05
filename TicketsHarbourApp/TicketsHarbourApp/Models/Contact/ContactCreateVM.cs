using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Contact
{
    public class ContactCreateVM
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;


        [Required]
        [MaxLength(30)]
        [Display(Name = "Names")]
        public string Names { get; set; } = null!;

        
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; } = null!;



    }
}
