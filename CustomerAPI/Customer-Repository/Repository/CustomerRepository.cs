using System;
using System.Collections.Generic;
using System.Linq;
using Customer_Entity.Context;
using Customer_Entity.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        private class ServiceResult<T>
        {
            public T Data { get; set; }

            public bool Success { get; set; }

            public string Message { get; set; }


        }

        public dynamic DeleteCustomer(int customerid)
        {

            var result = new ServiceResult<Customer>();

            using (var scope = _customerContext.Database.BeginTransaction())
            {

                try
                {
                    Customer customerData = _customerContext.Customers.Where(f => f.Id == customerid).FirstOrDefault();
                    List<CustomerAddres> cusomerAddressData = _customerContext.CustomerAddresses.Where(f => f.CustomerId == customerid).ToList();

                    foreach (CustomerAddres customerAddres in cusomerAddressData)
                    {
                        _customerContext.CustomerAddresses.Remove(customerAddres);

                    }

                    _customerContext.Customers.Remove(customerData);
                    _customerContext.SaveChanges();

                    result.Data = null;
                    result.Success = true;
                    result.Message = "customer Deleted Succesfully";
                    scope.Commit();

                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    result.Success = false;
                    result.Message = ex.Message;
                }
            }

            return result;
        }



        public dynamic SaveCustomer(Customer customer)
        {

            var result = new ServiceResult<Customer>();

            EntityEntry<Customer> data = null;

            using (var scope = _customerContext.Database.BeginTransaction())
            {

                try
                {
                    if (customer.Id == 0)
                    {
                        customer.CreatedUserid = "0";
                        customer.Created = new DateTime();
                        data = _customerContext.Customers.Add(customer);
                    }
                    else
                    {

                        foreach (CustomerAddres customerAddres in customer.CustomerAddreses)
                        {
                            if (customerAddres.Id == 0)
                            {
                                customerAddres.CreatedUserid = "0";
                                customerAddres.Created = new DateTime();
                            }

                        }

                        data = _customerContext.Customers.Update(customer);
                    }

                    _customerContext.SaveChanges();

                    result.Data = data.Entity;
                    result.Success = true;
                    result.Message = "customer successfully saved";
                    scope.Commit();

                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    result.Success = false;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

    }
}
