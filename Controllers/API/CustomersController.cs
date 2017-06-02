using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.API
{
  [Route("/api/[controller]")]
  public class CustomersController : Controller
  {

    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public CustomersController(ApplicationDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }


    [HttpGet]
    public async Task<IEnumerable<CustomerDto>> GetCustomers()
    {
      var customers = await context.Customers.ToListAsync();

      return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
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
    public async Task<IActionResult> NewCustomer([FromBody] Customer customer)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      context.Customers.Add(customer);
      context.SaveChanges();

      var customerInDb = await context.Customers.SingleOrDefaultAsync(c => c.Name == customer.Name);
      return Ok(customerInDb);
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