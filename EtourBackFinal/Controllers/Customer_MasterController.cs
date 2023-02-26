using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtourBackFinal.Model;

namespace EtourBackFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Customer_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Customer_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_Master>>> GetCustomerMaster()
        {
          if (_context.CustomerMaster == null)
          {
              return NotFound();
          }
            return await _context.CustomerMaster.ToListAsync();
        }

        // GET: api/Customer_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_Master>> GetCustomer_Master(int id)
        {
          if (_context.CustomerMaster == null)
          {
              return NotFound();
          }
            var customer_Master = await _context.CustomerMaster.FindAsync(id);

            if (customer_Master == null)
            {
                return NotFound();
            }

            return customer_Master;
        }


       /* //GET: api/Customer_Master/7869285852/Sagar2123
        [HttpGet("{phoneNo}/{password}")]
        public async Task<ActionResult<IEnumerable<Customer_Master>>> GetCustomer_Master(string phoneNo, string password)
        {
            if (_context.CustomerMaster == null)
            {
                return NotFound();
            }

            var customer_Master = from c in _context.CustomerMaster where c.PhoneNo == phoneNo  && c.Password == password select c;

            return Ok(customer_Master);
        }*/

     
        // PUT: api/Customer_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_Master(int id, Customer_Master customer_Master)
        {
            if (id != customer_Master.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_MasterExists(id))
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

        // POST: api/Customer_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_Master>> PostCustomer_Master(Customer_Master customer_Master)
        {
          if (_context.CustomerMaster == null)
          {
              return Problem("Entity set 'ETourContext.CustomerMaster'  is null.");
          }
            _context.CustomerMaster.Add(customer_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer_Master", new { id = customer_Master.CustomerId }, customer_Master);
        }


/*

        // POST: api/Customer_Master/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Login")]
        public async Task<ActionResult<Customer_Master>> Login(Customer_Master customer_Master)
        {
            if (_context.CustomerMaster == null)
            {
                return Problem("Entity set 'ETourContext.CustomerMaster'  is null.");
            }
            var query = from customer in _context.CustomerMaster
                         where customer.CustomerId ==  customer_Master.CustomerId
                         select new { customer };

            var result =  await query.ToListAsync();
            if(result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }*/

        // DELETE: api/Customer_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_Master(int id)
        {
            if (_context.CustomerMaster == null)
            {
                return NotFound();
            }
            var customer_Master = await _context.CustomerMaster.FindAsync(id);
            if (customer_Master == null)
            {
                return NotFound();
            }

            _context.CustomerMaster.Remove(customer_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_MasterExists(int id)
        {
            return (_context.CustomerMaster?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
