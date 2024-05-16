using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Services;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IUserService _UService;

        public CustomerController(ICustomerService service,IUserService userService)
        {
            _service = service;
            _UService = userService;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            try
            {
                var customers = await _service.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPost("Register")]
        public async Task<ActionResult<Customer>> RegisterCustomer(RegisterCustomerDTO customer)
        {
            try
            {
                var result = await _UService.Register(customer);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ReturnLoginDTO>> LoginCustomer(LoginCustomerDTO login)
        {
            try
            {
                var result = await _UService.Login(login);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
