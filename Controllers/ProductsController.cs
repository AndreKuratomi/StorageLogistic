using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

using StorageLogistic.Models;
using StorageLogistic.ViewModels;

using System.Diagnostics; 
using System.Linq;
using System.Threading.Tasks;

namespace StorageLogistic.Controllers;
public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context; //(_context variable typed ApplicationDbContext)

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // PRODUCTS LISTS:
    // GET: Products
    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.ToListAsync());
    }

    // GET: Products by id:

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var product = await _context.Products
            .Include(p => p.ProductHistories.OrderByDescending(h => h.ChangeDate))  // Get the history
            .FirstOrDefaultAsync(m => m.RequestId == id);

        if (product == null)
        {
            return NotFound();
        }

        // Get the most recent update
        var lastUpdate = product.ProductHistories.FirstOrDefault();

        var viewModel = new ProductDetails
        {
            Product = product,
            LastUpdate = lastUpdate  // Pass the most recent update
        };

        return View(viewModel);
    }

    // GET: Products/LowStock
    public async Task<IActionResult> LowStock()
    {
        var lowStockProducts = await _context.Products
                                            .Where(p => p.Amount < 10)
                                            .ToListAsync();

        return View(lowStockProducts);
    }

    // GET: Products/Stuck
    public async Task<IActionResult> Stuck()
    {
        var threeMonthsAgo = DateTime.UtcNow.AddMonths(-3);
        var stuckProducts = await _context.Products
                                        .Where(p => p.LastSoldDate == null || p.LastSoldDate < threeMonthsAgo)
                                        .ToListAsync();
        
        return View(stuckProducts);
    }

    // CREATE PRODUCT:

    // GET: Products/Create -> display the form for creating a new product.
    public IActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(
        "RequestId,ProductName,DateCreated,DateUpdated,Amount,Price,ProductType"
        )] Products product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // EDIT PRODUCT BY ID:
    // GET: Products/Edit/5 -> display form for this
    public async Task<IActionResult> Edit(int? id)
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
        return View(product);
    }
    // POST: Products/Edit/5 -> submit form data for edition
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind(
        "RequestId,ProductName,DateCreated,DateUpdated,Amount,Price,ProductType")] 
        Products product)
    {
        if (id != product.RequestId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.RequestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // DELETE PRODUCT BY ID:
    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FirstOrDefaultAsync(m => m.RequestId == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5 -> submit deletion
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
    
        if (product == null)
        {
            return NotFound();
        }
    
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    
        return Redirect("/");
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.RequestId == id);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
