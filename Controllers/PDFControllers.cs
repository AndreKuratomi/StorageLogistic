using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageLogistic.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StorageLogistic.Controllers
{
    public class PdfReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PdfReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /PdfReports/ProductsInStorage
        public async Task<IActionResult> ProductsInStorage()
        {
            try
            {
                var products = await _context.Products.ToListAsync();

                // Create the PDF document
                using (var stream = new MemoryStream())
                {
                    var pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream).CloseStream = false;
                    pdfDoc.Open();

                    // Add title to PDF
                    pdfDoc.Add(new Paragraph("Products in Storage"));
                    pdfDoc.Add(new Paragraph("\n"));

                    // Add product details in a table
                    var table = new PdfPTable(4); // 4 columns
                    table.AddCell("Product Name");
                    table.AddCell("Amount");
                    table.AddCell("Price");
                    table.AddCell("Product Type");

                    foreach (var product in products)
                    {
                        table.AddCell(product.ProductName);
                        table.AddCell(product.Amount.ToString());
                        table.AddCell(product.Price.ToString("C"));
                        table.AddCell(product.ProductType);
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();

                    stream.Position = 0;
                    return File(stream.ToArray(), "application/pdf", "ProductsInStorage.pdf");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /PdfReports/LowStockProducts
        public async Task<IActionResult> LowStockProducts()
        {
            try
            {
                var lowStockProducts = await _context.Products
                    .Where(p => p.Amount <= 10)
                    .ToListAsync();

                using (var stream = new MemoryStream())
                {
                    var pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream).CloseStream = false;
                    pdfDoc.Open();

                    pdfDoc.Add(new Paragraph("Low Stock Products"));
                    pdfDoc.Add(new Paragraph("\n"));

                    var table = new PdfPTable(4);
                    table.AddCell("Product Name");
                    table.AddCell("Amount");
                    table.AddCell("Price");
                    table.AddCell("Product Type");

                    foreach (var product in lowStockProducts)
                    {
                        table.AddCell(product.ProductName);
                        table.AddCell(product.Amount.ToString());
                        table.AddCell(product.Price.ToString("C"));
                        table.AddCell(product.ProductType);
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();

                    stream.Position = 0;
                    return File(stream.ToArray(), "application/pdf", "LowStockProducts.pdf");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /PdfReports/StorageIncomesAndOutcomes
        public async Task<IActionResult> StorageIncomesAndOutcomes()
        {
            try
            {
                var products = await _context.Products
                    .Include(p => p.ProductHistories)
                    .ToListAsync();

                using (var stream = new MemoryStream())
                {
                    var pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream).CloseStream = false;
                    pdfDoc.Open();

                    pdfDoc.Add(new Paragraph("Storage Incomes and Outcomes"));
                    pdfDoc.Add(new Paragraph("\n"));

                    foreach (var product in products)
                    {
                        pdfDoc.Add(new Paragraph($"Product: {product.ProductName}"));
                        pdfDoc.Add(new Paragraph("\n"));
                        var table = new PdfPTable(4);
                        table.AddCell("Change Date");
                        table.AddCell("Previous Amount");
                        table.AddCell("New Amount");
                        table.AddCell("Changed By");

                        foreach (var history in product.ProductHistories)
                        {
                            table.AddCell(history.ChangeDate.ToString("g"));
                            table.AddCell(history.PreviousAmount.ToString());
                            table.AddCell(history.NewAmount.ToString());
                            table.AddCell(history.ChangedBy);
                        }

                        pdfDoc.Add(table);
                        pdfDoc.Add(new Paragraph("\n"));
                    }

                    pdfDoc.Close();

                    stream.Position = 0;
                    return File(stream.ToArray(), "application/pdf", "StorageIncomesAndOutcomes.pdf");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /PdfReports/StuckProducts
        public async Task<IActionResult> StuckProducts()
        {
            try
            {
                var stuckProducts = await _context.Products
                    .Where(p => p.LastSoldDate == null)
                    .ToListAsync();

                using (var stream = new MemoryStream())
                {
                    var pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream).CloseStream = false;
                    pdfDoc.Open();

                    pdfDoc.Add(new Paragraph("Stuck Products (Never Sold)"));
                    pdfDoc.Add(new Paragraph("\n"));

                    var table = new PdfPTable(4);
                    table.AddCell("Product Name");
                    table.AddCell("Amount");
                    table.AddCell("Price");
                    table.AddCell("Product Type");

                    foreach (var product in stuckProducts)
                    {
                        table.AddCell(product.ProductName);
                        table.AddCell(product.Amount.ToString());
                        table.AddCell(product.Price.ToString("C"));
                        table.AddCell(product.ProductType);
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();

                    stream.Position = 0;
                    return File(stream.ToArray(), "application/pdf", "StuckProducts.pdf");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
