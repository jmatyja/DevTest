using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Models.Customer>> GetCustomersAsync()
        {
            return await context.Customers.Select(x => new Models.Customer
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).ToListAsync();
        }

        public async Task<Models.Customer> GetCustomerAsync(int id)
        {
            var dbCustomer = await context.Customers.FindAsync(id);
            return new Models.Customer
            {
                Id = dbCustomer.Id,
                Name = dbCustomer.Name,
                Type = dbCustomer.Type
            };
        }

        public async Task<Models.Customer> CreateCustomerAsync(CustomerCreate customer)
        {
            var addCustomer = new Database.Models.Customer
            {
                Name = customer.Name,
                Type = customer.Type
            };
            await context.Customers.AddAsync(addCustomer);
            await context.SaveChangesAsync();

            return new Models.Customer
            {
                Id = addCustomer.Id,
                Name = addCustomer.Name,
                Type = addCustomer.Type
            };
        }
    }
}
