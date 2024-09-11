using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageLogistic.Models
{
    public class ProductHistory
    {
        [Key]
        public int HistoryId { get; set; }  // Primary key

        public int ProductId { get; set; }  // Foreign key to Products
        public int PreviousAmount { get; set; }  // The amount before the update
        public int NewAmount { get; set; }  // The new amount after the update
        public DateTime ChangeDate { get; set; }  // When the change happened
        public string ChangedBy { get; set; } = "System";  // (Optional) Who made the update

        [ForeignKey("ProductId")]
        public Products? Product { get; set; }  // Navigation property to Products
    }
}
