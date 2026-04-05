namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        // Navigation Property
        public List<ContactInfo> Contacts
        {
            get; set;
        }
    }
}
