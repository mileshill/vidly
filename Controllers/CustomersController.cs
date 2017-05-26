using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        

        public IActionResult Details(int id)
        {
          //TODO: Implement Realistic Implementation
          var customer = GetCustomers()
            .SingleOrDefault(c => c.Id == id);


          if(customer == null)
            return NotFound(customer);
            
          return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> {
                 new Customer() { Name = "Josh Smith", Id = 1 },
                new Customer() { Name = "Mary Williams", Id = 2 }     
            };
        }
       
    }
}