using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuantumStock.Data;
using QuantumStock.Shared.Models;

namespace QuantumStock.Controllers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetAllBranchAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranchByIdAsync(Guid id)
        {
            var result = await _context.Branches.FindAsync(id);
            if (result == null)
                return NotFound("Branch not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranchAsync(Guid id)
        {
            var result = await _context.Branches.FindAsync(id);
            if (result == null)
                return NotFound("Branch not found");

            _context.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Branch>> UpdateBranchAsync(Guid id, Branch branch)
        {
            var dbBranch = await _context.Branches.FindAsync(id);
            if (dbBranch == null)
                return NotFound("Branch not found");

            dbBranch.Name = branch.Name;
            dbBranch.Address = branch.Address;
            dbBranch.Email = branch.Email;
            dbBranch.Location = branch.Location;
            dbBranch.Contact = branch.Contact;

            await _context.SaveChangesAsync();
            return Ok(dbBranch);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> AddBranchAsync(Branch newbranch)
        {
            _context.Branches.Add(newbranch);

            await _context.SaveChangesAsync();
            return Ok(newbranch);
        }
    }
}