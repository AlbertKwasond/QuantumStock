using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantumStock.Data;
using QuantumStock.Shared.Models;

namespace QuantumStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SalesListsController> _logger;

        public SalesListsController(ApplicationDbContext context, ILogger<SalesListsController> logge)
        {
            _context = context;
            _logger = logge;
        }

        // GET: api/SalesLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesList>>> GetSalesLists()
        {
            return await _context.SalesLists.ToListAsync();
        }

        // GET: api/SalesLists/5
        [HttpGet("{searchFromDate},{searchToDate}")]
        public async Task<ActionResult> GetSalesList(DateTime searchFromDate, DateTime searchToDate)
        {
            try
            {
                var filteredData = _context.SalesLists
                             .Include(p => p.Staff)
                             .Include(p => p.Payments)
                             .Include(p => p.Customer)
                             .Where(item => item.DateTime.Date >= searchFromDate && item.DateTime.Date <= searchToDate && item.Status == "Completed")
                             .ToList();

                var purchData = await _context.PaymentItemLists
                                 .Where(item => item.DateTime.Date >= searchFromDate &&
                                                item.DateTime.Date <= searchToDate)
                                 .SumAsync(s => s.Price);

                var paymentItem = await _context.PaymentItemLists
                    .Where(item => item.DateTime.Date >= searchFromDate &&
                                   item.DateTime.Date <= searchToDate)
                    .ToListAsync();

                var groupedData = filteredData
                                  .GroupBy(item => item.DateTime.Date)
                                  .Select(group => new
                                  {
                                      Date = group.Key,
                                      Items = group.ToList()
                                  })
                                  .ToList();

                return Ok(new
                {
                    GroupedData = groupedData,
                    PaymentItem = paymentItem,
                    PurchaseDataSum = purchData
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching sales list.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        // PUT: api/SalesLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesList(int id, SalesList salesList)
        {
            if (id != salesList.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesListExists(id))
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

        // POST: api/SalesLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesList>> PostSalesList(SalesList salesList)
        {
            _context.SalesLists.Add(salesList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesList", new { id = salesList.Id }, salesList);
        }

        // DELETE: api/SalesLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesList(int id)
        {
            var salesList = await _context.SalesLists.FindAsync(id);
            if (salesList == null)
            {
                return NotFound();
            }

            _context.SalesLists.Remove(salesList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesListExists(int id)
        {
            return _context.SalesLists.Any(e => e.Id == id);
        }
    }
}