using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_S_Reality.Models
{
    public class Property
    {
        public int PropertyID { get; set; }

        public int SellerID { get; set; }
        [ForeignKey("SellerID")]
        public BuyerSeller? Seller { get; set; }

        // Buyer 
        public int? BuyerID { get; set; }
        [ForeignKey("BuyerID")]
        public BuyerSeller? Buyer {  get; set; }


        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        [Range(50000, 10000000)]
        public decimal Price { get; set; }

        public int NeighborhoodID { get; set; }
        public Neighborhood? Neighborhood { get; set; }

        public int AgentID { get; set; }
        public Agent? Agent { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string? Type { get; set; }

        [Range(0, 20)]
        public int Bedrooms { get; set; }

        [Range(0, 10)]
        public int Bathrooms { get; set; }


        [Range(100, 20000)]
        public int SquareFootage { get; set; }

        [DataType(DataType.Date)]
        public DateTime ListedDate { get; set; }

        public string? Status { get; set; }


        public bool HasGarage { get; set; }
        public bool HasGarden { get; set; }

        public bool IsFurnished { get; set; }


        [Range (0, 5)]
        public double Rating { get; set; }

        public decimal PricePerSquareFoot => SquareFootage > 0 ? Price / SquareFootage : 0;
       
    }
}
