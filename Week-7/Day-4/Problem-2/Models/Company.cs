namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Models
{
    public class Company
    {
        
            [Key]
            public int CompanyId { get; set; }

            [Required]
            public string CompanyName { get; set; } = string.Empty

            // Navigation Property
            public List<ContactInfo> Contacts { get; set; }
        
    }
}

