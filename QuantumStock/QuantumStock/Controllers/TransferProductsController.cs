using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using QuantumStock.Client.Pages.TransferProductsToBranchs;
using QuantumStock.Data;
using QuantumStock.Shared.Models;

namespace QuantumStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TransferProductsController> _logger;

        public TransferProductsController(ApplicationDbContext context, ILogger<TransferProductsController> logger)
        {
            _context = context;
            _logger = logger; // Initialize logger
        }

        // GET: api/TransferProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferProduct>>> GetTransferProducts()
        {
            return await _context.TransferProducts.ToListAsync();
        }

        // GET: api/TransferProducts/5
        [HttpGet("{branchId}")]
        public async Task<ActionResult<IEnumerable<TransferProduct>>> GetTransferProduct(int branchId)
        {
            try
            {
                var transferProducts = await _context.TransferProducts
                    .Where(tp => tp.BranchId == branchId)
                    .ToListAsync();

                if (transferProducts == null || !transferProducts.Any())
                {
                    _logger.LogWarning("No transfer products found for branch ID {BranchId}", branchId);
                    return NotFound();
                }

                return Ok(transferProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting transfer products for branch ID {BranchId}", branchId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/TransferProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransferProduct(int id, TransferProduct transferProduct)
        {
            if (id != transferProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TransferProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransferProduct>> PostTransferProduct(TransferProduct transferProduct)
        {
            // Fetch the product from the database
            var product = await _context.Products.Where(x => x.Id == transferProduct.ProductsId).FirstOrDefaultAsync();
            // Fetch the branches from the database
            var branches = await _context.Branches.Where(x => x.Id == transferProduct.BranchId).FirstOrDefaultAsync();
            // Check if the product exists
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Check if the quantity to be transferred exceeds the available quantity
            if (transferProduct.Qty > product.TotalQty)
            {
                return BadRequest("The quantity entered exceeds the total available quantity of products.");
            }

            // Check if a transfer product with the same product and branch exists
            bool isProductDuplicate = await CheckProductDuplicateFields(transferProduct.ProductsId, transferProduct.BranchId);

            if (isProductDuplicate)
            {
                // Fetch the existing transfer product
                var existingTransferProduct = await _context.TransferProducts
                    .Where(c => c.ProductsId == transferProduct.ProductsId && c.BranchId == transferProduct.BranchId)
                    .FirstOrDefaultAsync();

                if (existingTransferProduct != null)
                {
                    // Update the quantities
                    product.TotalQty -= transferProduct.Qty;
                    existingTransferProduct.Qty += transferProduct.Qty;

                    _context.Products.Update(product);
                    _context.TransferProducts.Update(existingTransferProduct);

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                // Add the new transfer product
                transferProduct.Name = product.Name;
                transferProduct.SellingPrice = product.SellingPrice;
                transferProduct.BranchName = branches.Name;
                product.TotalQty -= transferProduct.Qty;

                _context.Products.Update(product);
                _context.TransferProducts.Add(transferProduct);

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTransferProduct", new { id = transferProduct.Id }, transferProduct);
            }
            return Ok();
        }

        private async Task<bool> CheckProductDuplicateFields(int productsId, int branchId)
        {
            return await _context.TransferProducts.AnyAsync(x => x.ProductsId == productsId && x.BranchId == branchId);
        }

        // DELETE: api/TransferProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransferProduct(int id)
        {
            var transferProduct = await _context.TransferProducts.FindAsync(id);
            if (transferProduct == null)
            {
                return NotFound();
            }

            _context.TransferProducts.Remove(transferProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransferProductExists(int id)
        {
            return _context.TransferProducts.Any(e => e.Id == id);
        }
    }
}