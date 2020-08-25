using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel[] Getcustomers();

        CustomerModel GetCustomer(int customerId);

        CustomerModel CreateCustomer(BaseCustomerModel model);
    }
}
