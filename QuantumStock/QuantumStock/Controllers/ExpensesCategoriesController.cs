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
    public class ExpensesCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExpensesCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpensesCategory>>> GetExpensesCategories()
        {
            return await _context.ExpensesCategories.ToListAsync();
        }

        // GET: api/ExpensesCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpensesCategory>> GetExpensesCategory(int id)
        {
            var expensesCategory = await _context.ExpensesCategories.FindAsync(id);

            if (expensesCategory == null)
            {
                return NotFound();
            }

            return expensesCategory;
        }

        // PUT: api/ExpensesCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpensesCategory(int id, ExpensesCategory expensesCategory)
        {
            if (id != expensesCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(expensesCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesCategoryExists(id))
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

        // POST: api/ExpensesCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpensesCategory>> PostExpensesCategory(ExpensesCategory expensesCategory)
        {
            _context.ExpensesCategories.Add(expensesCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpensesCategory", new { id = expensesCategory.Id }, expensesCategory);
        }

        // DELETE: api/ExpensesCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpensesCategory(int id)
        {
            var expensesCategory = await _context.ExpensesCategories.FindAsync(id);
            if (expensesCategory == null)
            {
                return NotFound();
            }

            _context.ExpensesCategories.Remove(expensesCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpensesCategoryExists(int id)
        {
            return _context.ExpensesCategories.Any(e => e.Id == id);
        }
    }
}
