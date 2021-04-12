using System;
using Customer_Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Customer_Entity.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddres> CustomerAddresses { get; set; }
    }
}
