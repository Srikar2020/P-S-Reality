using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class Agent
    {
        [DisplayName("Agent ID")]
        public int AgentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Range(0,50)]
        [DisplayName("Years of Experience")]
        public int ExperienceYears { get; set; }


        [StringLength(100)]
        public string Specialization { get; set; }

        [Range(0 ,5)]
        [DisplayName("Average Rating")]
        public double AverageRating { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Joined")]
        public DateTime DateJoined { get; set; }

        public Agent()
        {
            Properties = new List<Property>();
        }
        public int GetTotalPropertiesListed()
        {
            return Properties.Count;
        }

        public ICollection<Property> Properties { get; set; } = new List<Property>();

        
    }
}
