using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreDemo.Models;
using EFCoreDemo.Data;

namespace EFCoreDemo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly gCoreDbContext _db;

        public CustomerService(gCoreDbContext db)
        {
            _db = db;
        }

        public List<Customer> GetCustomers() => _db.Customers.ToList();
        public Customer GetCustomer(int id) => _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);

        public void AddCustomer(Customer newCustomer)
        {
            if (_db.Customers.Any(customer => customer.CustomerId == newCustomer.CustomerId))
            {
                throw new ArgumentOutOfRangeException("Customer id already in use.");
            }
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
        }

        public void UpdateCustomer(int id, Customer updatedCustomer)
        {
            if (_db.Customers.Any(customer => customer.CustomerId == id))
            {
                var customerToUpdate = _db.Customers.First(customer => customer.CustomerId == id);
                customerToUpdate.Email = updatedCustomer.Email;
                customerToUpdate.FirstName = updatedCustomer.FirstName;
                customerToUpdate.LastName = updatedCustomer.LastName;
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Could not find customer by that ID.");
            }
        }

        public void DeleteCustomer(int id)
        {
            if (_db.Customers.Any(customer => customer.CustomerId == id))
            {
                var customerToDelete = _db.Customers.First(customer => customer.CustomerId == id);
                _db.Customers.Remove(customerToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Could not find customer by that ID.");
            }
        }
    }
}