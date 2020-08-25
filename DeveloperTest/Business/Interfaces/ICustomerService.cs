using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetcustomersAsync();

        Task<Customer> GetCustomerAsync(int customerId);

        Task<Customer> CreateCustomer(CustomerCreate model);
    }
}
