using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Customer_Entity.Entity;
using Customer_Repository.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPI.Controllers
{
    public class CustomerController : ControllerBase
    {

        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("~/[controller]/GetCustomerById/{Id}")]
        public Customer GetCustomerById(int Id)
        {
            return _customerRepository.GetCustomerById(Id);
        }

        [HttpGet]
        [Route("~/[controller]/GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        [HttpPost]
        [Route("~/[controller]/SaveCustomer")]
        public dynamic SaveCustomer([FromBody] JsonElement customer)
        {
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(customer.GetRawText());

            return _customerRepository.SaveCustomer(data);
        }


        [HttpDelete]
        [Route("~/[controller]/DeleteCustomer/{Id}")]
        public dynamic DeleteCustomer([FromBody] int customerid)
        {
            //  _customerRepository.DeleteCustomer(customerid);
            return _customerRepository.GetAllCustomers();
        }
    }
}
