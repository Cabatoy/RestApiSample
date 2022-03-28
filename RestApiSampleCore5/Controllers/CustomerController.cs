using System.Net;
using Entities.Abstract;
using Entities.Core.Dal;
using EntitiesAndCore.Core.Dal;
using EntitiesAndCore.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace RestApiSampleCore5.Controllers
{

    /// <summary>
    /// Customer jobs
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController :ControllerBase
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// const
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get All Customers..
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _customerService.GetCustomerList();
            if (result.Success == HttpStatusCode.OK)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Get Customer with Id
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "getById/{customerId:int}")]
        //[Route("getById/{customerId}")]
        public IActionResult GetById(int customerId)
        {
            var result = _customerService.GetCustomerById(customerId);
            if (result.Success == HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        /// <summary>
        /// Get Customer with Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("getListByNation/{nation}")]
        //[Route("getById/{customerId}")]
        public IActionResult GetListByNation(string nation)
        {
            var result = _customerService.GetCustomerListWithNation(nation);
            if (result.Success == HttpStatusCode.OK && result.Data.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        ///  Add Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        //[Route("add/{customer}")]
        public IActionResult Add(DtoCustomer customer)
        {
            var result = _customerService.Add(Converter(customer));

            if (result.Success != HttpStatusCode.OK)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }


        /// <summary>
        /// Update Customer
        /// </summary>
        /// <returns></returns>
        //[HttpPost(template: "update")]
        [HttpPut(template: "update")]
        //[Route("update/{customer}")]
        public IActionResult Update(DtoCustomer customer)
        {
            var result = _customerService.Update(Converter(customer));

            if (result.Success == HttpStatusCode.OK)
            {
                return Ok(result);
            }
            else
                return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete Customer . Flagged Deleted=true
        /// not null NationalityNumber 
        /// </summary>
        /// <returns></returns>
        [HttpPost(template: "delete")]
        //[Route("Delete/{customer}")]
        public IActionResult Delete(DtoCustomer customer)
        {

            var result = _customerService.Delete(PrepareForDelete(Converter(customer)));
            if (result.Success == HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        private Customer Converter(DtoCustomer dtoCustomer)
        {
            var customer = new Customer()
            {
                Id = dtoCustomer.Id,
                FullName = dtoCustomer.FullName,
                Nationality = dtoCustomer.Nationality,
                NationalityNumber = dtoCustomer.NationalityNumber,
                PhoneNumber = dtoCustomer.PhoneNumber,
                CustomerStatus = dtoCustomer.CustomerStatus,
                Deleted = dtoCustomer.Deleted
            };

            return StatusChanger(customer);
        }
        private Customer StatusChanger(Customer customer)
        {
            switch (customer.CustomerStatus)
            {
                case CustomerStatus.OutofScope:
                    customer.CustomerStatusMeaning = "Out of Scope";
                    break;
                case CustomerStatus.Qualified:
                    customer.CustomerStatusMeaning = "Qualified";
                    break;
                case CustomerStatus.TakenForProcessing:
                    customer.CustomerStatusMeaning = "Taken For Processing";
                    break;
            }

            return customer;
        }

        private static Customer PrepareForDelete(Customer customer)
        {
            if (customer.Deleted)
                return customer;
            else
            {
                customer.Deleted = true;
            }

            return customer;
        }

    }
}
