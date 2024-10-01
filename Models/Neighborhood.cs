using System.ComponentModel.DataAnnotations;

namespace P_S_Reality.Models
{
    public class Neighborhood
    {
        public int NeighborhoodID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Range (0, 100000000)]
        public decimal AveragePrice { get; set; }

        [Range (0, 10)]
        public double PopularityScore { get; set; }
        public int Population { get; set; }
        public string CrimeRate { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();

        public int GetTotalProperties()
        {
            return Properties?.Count ?? 0;
        }


        
    }
}
