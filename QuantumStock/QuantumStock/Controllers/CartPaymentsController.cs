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
    public class CartPaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CartPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartPayment>>> GetCartPayments()
        {
            return await _context.CartPayments.ToListAsync();
        }

        // GET: api/CartPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartPayment>> GetCartPayment(int id)
        {
            var cartPayment = await _context.CartPayments.FindAsync(id);

            if (cartPayment == null)
            {
                return NotFound();
            }

            return cartPayment;
        }

        // PUT: api/CartPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartPayment(int id, CartPayment cartPayment)
        {
            if (id != cartPayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartPaymentExists(id))
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

        // POST: api/CartPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartPayment>> PostCartPayment(CartPayment cartPayment)
        {
            var product = await _context.Products.Where(x => x.Id == cartPayment.ProductsId).FirstOrDefaultAsync();

            var submitCart = new CartPayment
            {
                ProductsId = product.Id,
                CustomerId = cartPayment.CustomerId,
                ItemName = product.Name,
                Qty = cartPayment.Qty,
                Cost = product.SellingPrice,

                OrderNum = cartPayment.OrderNum,
                Price = product.SellingPrice
            };
            _context.CartPayments.Add(submitCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartPayment", new { id = cartPayment.Id }, cartPayment);
        }

        // DELETE: api/CartPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartPayment(int id)
        {
            var cartPayment = await _context.CartPayments.FindAsync(id);
            if (cartPayment == null)
            {
                return NotFound();
            }

            _context.CartPayments.Remove(cartPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartPaymentExists(int id)
        {
            return _context.CartPayments.Any(e => e.Id == id);
        }
    }
}