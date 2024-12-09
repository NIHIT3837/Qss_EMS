using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Data;
using WebApiDemo.Models;
using WebAppiDemo.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //private static readonly List<Employee> employees = new List<Employee>
        //{
        //    new Employee { Id = 1, FirstName = "John", LastName = "Doe", Role = "Developer", DateOfJoining = "2023-01-01", Manager = "Jane Smith" },
        //    new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Role = "Manager", DateOfJoining = "2020-03-15", Manager = "N/A" },
        //    new Employee { Id = 3, FirstName = "Alice", LastName = "Johnson", Role = "Developer", DateOfJoining = "2022-07-10", Manager = "Jane Smith" }
        //        };

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);  // HTTP 200 with the list of employees
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");  // HTTP 404
            }
            return Ok(employee);  // HTTP 200 with the employee data
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                return BadRequest("First name and Last name are required.");  // HTTP 400 Bad Request
            }

            var addedEmployee = await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = addedEmployee.Id }, addedEmployee);  // HTTP 201 Created
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, updatedEmployee);
            if (employee == null)
            {
                return NotFound("Employee not found.");  // HTTP 404 Not Found
            }

            return Ok(employee);  // HTTP 200 OK
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _employeeService.DeleteEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");  // HTTP 404 Not Found
            }

            return Ok(employee);  // HTTP 200 OK with the deleted employee
        }
    }
}