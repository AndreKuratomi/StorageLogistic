using System;
using System.ComponentModel.DataAnnotations;

namespace StorageLogistic.Models
{
    public class Product
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
    }
}

