﻿using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return employees.ToList();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployeePhone(int id, string phoneNumber)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phoneNumber);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [Route("GetEmployeeByPhone")] // two method are same so we added the route
        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployeeByPhone(string phoneNumber)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phoneNumber);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
