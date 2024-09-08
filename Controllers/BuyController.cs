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

        // GET: Buy/Create
        public IActionResult Create()
        {
            return View();
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

                //  Update product
                product.Amount += buyModel.Amount;
                product.LastSoldDate = null; //?

                _context.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
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

    public class BuyProductViewModel
    {
        public int RequestId { get; set; }
        public int Amount { get; set; }
    }
}