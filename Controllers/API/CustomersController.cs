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
    public async Task<IActionResult> GetCustomer(int id)
    {
      // var customer = await context.Customers
      //     .SingleOrDefault(c => c.Id == id);

      var customer = await context.Customers
          .Include(m => m.MembershipType)
          .SingleOrDefaultAsync(c => c.Id == id);


      if (customer == null)
        return NotFound();

      
      return Ok(mapper.Map<Customer, CustomerDto>(customer));
    }


    [HttpPost]
    public async Task<IActionResult> NewCustomer([FromBody] CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var customer = mapper.Map<CustomerDto, Customer>(customerDto);

      context.Customers.Add(customer);
      context.SaveChanges();

      customerDto.Id = customer.Id;
      return Ok(customerDto);
    }

    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();


      var customerInDb = await context.Customers
          .SingleOrDefaultAsync(c => c.Id == id);

      if (customerInDb == null)
        return NotFound();


      mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

      context.SaveChanges();

      return Ok(customerDto);
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