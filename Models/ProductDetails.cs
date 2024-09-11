using StorageLogistic.Models;

namespace StorageLogistic.ViewModels
{
    public class ProductDetails
    {
        public Products? Product { get; set; }  // The main product data
        public ProductHistory? LastUpdate { get; set; }  // The most recent update
    }
}
