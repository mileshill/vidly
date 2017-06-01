using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;

namespace vidly.Controllers.API
{
  [Route("/api/[controller]")]
  public class CustomersController : Controller
  {

    private readonly ApplicationDbContext context;

    public CustomersController(ApplicationDbContext context)
    {
        this.context = context;
    }


    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
      return context.Customers.ToList();
    }

    [Route("{id:int}")]
    [HttpGet]
    public IActionResult GetCustomer(int id)
    {
        // var customer = await context.Customers
        //     .SingleOrDefault(c => c.Id == id);

        var customer = context.Customers
            .Include(m => m.MembershipType)
            .SingleOrDefault(c => c.Id == id);
                

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }


    [HttpPost]
    public IActionResult NewCustomer([FromBody] Customer customer)
    {
        if(!ModelState.IsValid)
            return BadRequest();

        context.Customers.Add(customer);
        context.SaveChanges();
        return Ok(customer);
    }

    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var customerInDb = await context.Customers
            .SingleOrDefaultAsync(c => c.Id == id);
        
        if (customerInDb == null)
            return NotFound();

    
        customerInDb.Name = customer.Name;
        customerInDb.Birthdate = customer.Birthdate;
        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        customerInDb.MembershipTypeId = customer.MembershipTypeId;
        
        context.SaveChanges();
        
        return Ok(customer);
    }

    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await context.Customers
            .SingleOrDefaultAsync(c => c.Id == id);

        if (customer == null)
            return NotFound();

        context.Remove(customer);
        context.SaveChanges();
        return Ok();
    }

  }
}