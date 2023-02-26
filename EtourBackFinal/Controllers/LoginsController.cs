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
    public class LoginsController : ControllerBase
    {
        private readonly ETourContext _context;

        public LoginsController(ETourContext context)
        {
            _context = context;
        }

       

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Login>>> PostLogin(Login login)
        {
          if (login == null)
          {
              return Problem("Enter Data to Login");
          }
            

            var customer = await _context.CustomerMaster.FirstOrDefaultAsync((customer) => customer.PhoneNumber == login.PhoneNo && customer.Password == login.Password);

            if(login.PhoneNo.Equals(customer.PhoneNumber) && login.Password.Equals(customer.Password))
            {
                return Ok(customer);
            }


            return BadRequest("Invalid PhoneNo. OR Password") ;
        }

       
    }
}
