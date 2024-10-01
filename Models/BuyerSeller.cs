using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class BuyerSeller
    {
        public int BuyerSellerID { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }

        public string PreferredContactMethod { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }

        public int GetTotalListedProperties()
        {
            return ListedProperties?.Count ?? 0;
        }

        public ICollection<Property> ListedProperties { get; set; } = new List<Property>();

        public ICollection<Property> InterestedProperties { get; set; } = new List<Property>();
    }
}
