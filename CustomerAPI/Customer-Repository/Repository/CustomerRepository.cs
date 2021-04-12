using System;
using System.Collections.Generic;
using System.Linq;
using Customer_Entity.Context;
using Customer_Entity.Entity;

namespace Customer_Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private bool _disposed;
        private CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _customerContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public Customer GetCustomerById(int Id)
        {
            var result = _customerContext.Customers.Where(f => f.Id == Id).FirstOrDefault();

            return result;
        }


        public List<Customer> GetAllCustomers()
        {
            var result = _customerContext.Customers.ToList();

            return result;
        }

    }
}
