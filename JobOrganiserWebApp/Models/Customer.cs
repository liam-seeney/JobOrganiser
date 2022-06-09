using System.ComponentModel.DataAnnotations;

namespace JobOrganiserWebApp.Models
{
    public class Customer
    {
        private string? _fullName;
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string? EmailAddress { get; set; }

        public string FullName()
        {
            if (FirstName != null && LastName != null)
            {
                _fullName = FirstName + " " + LastName;
                return _fullName;
            }
            else
                return "No Name!";
        }
    }
}
