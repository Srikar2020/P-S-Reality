using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class BuyerSeller
    {
        [DisplayName("Buyer/Seller ID")]
        public int BuyerSellerID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Full Name")]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string? EmailAddress { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Role { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Registered")]
        public DateTime? DateRegistered { get; set; }

        [DisplayName("Preferred Contact Method")]
        public string? PreferredContactMethod { get; set; }


        public ICollection<Property> InterestedProperties { get; set; } = new List<Property>();

        public ICollection<Property> ListedProperties { get; set; } = new List<Property>();
    }
}

