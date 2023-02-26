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
    public class SearchesController : ControllerBase
    {
        private readonly ETourContext _context;

        public SearchesController(ETourContext context)
        {
            _context = context;
        }

        

        // POST: api/Searches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Search>> PostSearch(Search search)
        {
          if (search == null)
          {
              return Problem("Enter Valid data to Search");
            }
            /*  _context.Search.Add(search);*//*
              await _context.SaveChangesAsync();*/

            //var sum;
            

            var query = from dates in _context.DateMaster
                        join category in _context.CategoryMaster
                        on dates.MasterId equals category.MasterId
                        join costs in _context.CostMaster on category.MasterId equals costs.MasterId
                        where (dates.DepartureDate == search.StartDate || dates.EndDate== search.EndDate) && (costs.Cost >= search.MinCost && costs.Cost<= search.MaxCost)
                        && (dates.NoOfDays== search.NoOfDays)
                        select new 
                        {
                            category.CategoryId,
                            category.CategoryName,
                            dates.DepartureDate,
                            dates.EndDate,
                            dates.NoOfDays,
                            costs.Cost
                        };

            var result = await query.ToListAsync();

            if(result ==  null)
            {
                return NotFound();
            }


            return Ok(result);
        }


       
    }
}
