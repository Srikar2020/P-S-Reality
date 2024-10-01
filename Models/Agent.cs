using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class Agent
    {
        public int AgentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Range(0,50)]
        public int ExperienceYears { get; set; }


        [StringLength(100)]
        public string Specialization { get; set; }

        [Range(0 ,5)]
        public double AverageRating { get; set; }

        [DataType(DataType.Date)]
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
