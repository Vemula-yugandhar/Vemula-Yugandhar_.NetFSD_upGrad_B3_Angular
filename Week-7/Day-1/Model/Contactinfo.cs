using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Day_3.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Required]
        [Range(6000000000, 9999999999)]
        public long PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }


    }
}
