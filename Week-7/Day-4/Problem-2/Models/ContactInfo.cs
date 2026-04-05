namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Models
{
    public class ContactInfo
    {
            [Key]
            public int ContactId { get; set; }

            [Required]
            public string FirstName { get; set; } 

            public string LastName { get; set; } 

            [Required]
            public string EmailId { get; set; } 

            public long MobileNo { get; set; }

            public string Designation { get; set; } 

            // Foreign Keys
            public int CompanyId { get; set; }
            public int? DepartmentId { get; set; }

            // Navigation Properties
            public Company Company { get; set; }
            public Department Department { get; set; }
    }
}


