using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext context;
        public CustomersController(ApplicationDbContext context)
        {
            this.context = context;

        }
        public ViewResult Index()
        {
            var customers = context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            //var customers = GetCustomers();
            return View(customers);
        }


        public IActionResult Details(int id)
        {
            //TODO: Implement Realistic Implementation
            var customer = context.Customers
              .Include(c => c.MembershipType)
              .SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return NotFound(customer);

            return View(customer);
        }

        public IActionResult New()
        {
          var membershipTypes = context.MembershipTypes.ToList();

          var viewModel = new NewCustomerViewModel()
          {
            MembershipTypes = membershipTypes,
          };

          //TODO: Implement Realistic Implementation
          return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            //TODO: Implement Realistic Implementation
            return RedirectToAction("Index", "Customers");
        }

    }
}