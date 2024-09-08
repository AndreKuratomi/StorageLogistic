using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageLogistic.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StorageLogistic.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales/Create -> form sales display
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,Amount")] SaleProductViewModel saleModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(saleModel.RequestId);
                if (product == null)
                {
                    return NotFound();
                }

                if (product.Amount < saleModel.Amount)
                {
                    ModelState.AddModelError("", "Not enough stock to complete the sale.");
                    return View(saleModel);
                }

                // Update product
                product.Amount -= saleModel.Amount;
                product.LastSoldDate = DateTime.UtcNow;
                product.SoldAmount += saleModel.Amount;

                _context.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(saleModel);
        }

        // GET: Sales/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
    }

    public class SaleProductViewModel
    {
        public int RequestId { get; set; }
        public int Amount { get; set; }
    }
}