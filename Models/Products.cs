using System;
using System.ComponentModel.DataAnnotations;

namespace StorageLogistic.Models
{
    public class Products
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public int Amount { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string ProductType { get; set; } = string.Empty;

        // Tracking sales and stock levels:
        public DateTime? LastSoldDate { get; set; }
        public int SoldAmount { get; set; }
    }
}

