using System.ComponentModel.DataAnnotations;

namespace TicketsHarbourApp.Models.Client
{
    public class ClientDeleteVM
    {
        public string Id { get; set; } = null;

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null;

        [Required]
        public string Address { get; set; } = null;

        [Required]
        public string Email { get; set; } = null!;

    }
}
