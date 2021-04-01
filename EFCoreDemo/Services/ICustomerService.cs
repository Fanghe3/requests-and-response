using EFCoreDemo.Models;
using System.Collections.Generic;

namespace EFCoreDemo.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);

        void AddCustomer(Customer newCustomer);

        void UpdateCustomer(int id, Customer updatedCustomer);

        void DeleteCustomer(int id);
    }
}