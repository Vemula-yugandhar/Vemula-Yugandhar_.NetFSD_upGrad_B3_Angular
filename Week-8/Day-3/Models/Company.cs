using System.ComponentModel.DataAnnotations;

namespace Web_API_Day_1.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

    }
}
