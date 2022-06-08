using System.ComponentModel.DataAnnotations;

namespace JobOrganiserWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string? EmailAddress { get; set; }
    }
}
