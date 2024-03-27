using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.CustomerModels;
using NegocioInversiones.Services;

namespace NegocioInversiones.Controllers
{
    [Route("api/v2/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("create-customer")]
        public ActionResult<Customer> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                Customer customer = _customerService.CreateCustomer(createCustomerDto);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customer-profile")]
        public ActionResult GetCustomerByCivilId(string CustomerId, int? CustomerIdType)
        {
            Customer customer;
            try
            {
                if (CustomerIdType.HasValue)
                {
                    Console.WriteLine("LLamando Civil ID");
                    customer = _customerService.GetCustomerByCivilId(CustomerId, CustomerIdType);
                }
                else
                {
                    Console.WriteLine("Llamando solo ID");
                    int id = int.Parse(CustomerId);
                    customer = _customerService.GetCustomerByCustomerId(id);
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound("No se encontro cliente con este ID");

            }

        }



    }
}
