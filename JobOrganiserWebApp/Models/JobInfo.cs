namespace JobOrganiserWebApp.Models
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public DateTime EstCompletionDate { get; set; }
        public Customer? CustomerName { get; set; }
    }
}
