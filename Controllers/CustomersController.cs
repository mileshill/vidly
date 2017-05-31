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

          var viewModel = new CustomerFormViewModel()
          {
            MembershipTypes = membershipTypes,
          };

          //TODO: Implement Realistic Implementation
          return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {

            // Validate input bing saved
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            // Add new customer
            if (customer.Id == 0)
            {   
                context.Customers.Add(customer);
            }
            // Update existing customers
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            // Commit to Database
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
         var customer = context.Customers
            .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel()
            { 
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            
            };    
            return View("CustomerForm", viewModel);
        }

    }
}