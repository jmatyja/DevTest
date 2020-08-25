using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int customerId);

        Task<Customer> CreateCustomerAsync(CustomerCreate model);
    }
}
