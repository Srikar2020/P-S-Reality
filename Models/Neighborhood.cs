using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class Neighborhood
    {
        [DisplayName("Neighborhood ID")]
        public int NeighborhoodID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? City { get; set; }

        [Required]
        [StringLength(100)]
        public string? State { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Zip Code")]
        public string? ZipCode { get; set; }

        [Range (0, 100000000)]
        [DisplayName("Average Price")]
        public decimal AveragePrice { get; set; }

        [Range (0, 10)]
        [DisplayName("Popluarity Score")]
        public double PopularityScore { get; set; }
        public int Population { get; set; }

        [DisplayName("Crime Rate")]
        public string? CrimeRate { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();

        public int GetTotalProperties()
        {
            return Properties?.Count ?? 0;
        }


        
    }
}

