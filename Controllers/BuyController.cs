using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageLogistic.Models;
using System;
using System.Threading.Tasks;

namespace StorageLogistic.Controllers
{
    public class BuyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE:
        // GET: Buy/Create/{id}
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Initialize the buy model with the product's request ID
            var buyModel = new BuyProduct
            {
                RequestId = product.RequestId,
                AvailableAmount = product.Amount,
                Amount = 0 // default amount, user will input the amount
            };

            return View(buyModel);
        }

        // POST: Buy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId, Amount")] BuyProduct buyModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(buyModel.RequestId);
                if (product == null)
                {
                    return NotFound();
                }

                // Store previous amount
                var previousAmount = product.Amount;

                //  Update product
                if (product.Amount < buyModel.Amount)
                {
                    ModelState.AddModelError("Amount", "Quantidade a comprar maior que a disponível.");
                    return View(buyModel);
                }

                product.Amount -= buyModel.Amount;
                product.SoldAmount += buyModel.Amount;  // Update the total sold amount
                product.LastSoldDate = DateTime.Now;  // Set the last sold date
                product.DateUpdated = DateTime.Now;  // Update the date for last modification

                // Create a history entry for this update
                var productHistory = new ProductHistory
                {
                    ProductId = product.RequestId,
                    PreviousAmount = previousAmount,
                    NewAmount = product.Amount,
                    ChangeDate = DateTime.Now,
                    ChangedBy = "System"  // You can use the logged-in user if available
                };
                
                _context.ProductHistories.Add(productHistory);

                _context.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Products");
            }
            return View(buyModel);
        }

        // GET: Buy/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

    }

    public class BuyProduct
    {
        public int RequestId { get; set; }
        public int Amount { get; set; }
        public int AvailableAmount { get; set; }
    }
}