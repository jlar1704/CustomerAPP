using System;
using System.Collections.Generic;
using Customer_Entity.Entity;

namespace Customer_Repository.Repository
{

    public interface ICustomerRepository
    {
        Customer GetCustomerById(int Id);
        List<Customer> GetAllCustomers();
        dynamic SaveCustomer(Customer customer);
        dynamic DeleteCustomer(int customerid);
        dynamic DeleteAdressCustomer(int addressid);
    }
}
