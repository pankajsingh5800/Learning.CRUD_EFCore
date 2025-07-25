using CRUD_EFCore.Models;
using CRUD_EFCore.Models.Employees;
using CRUD_EFCore.Services.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.AppConfig;

namespace CRUD_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;
        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        [Route("getAllEmployees")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var _response = await _employeeService.GetAllEmployeesAsync();
            return Ok(_response);
        }

        [HttpGet]
        [Route("getEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            var _response = await _employeeService.GetEmployeeByIdAsync(employeeId);
            return Ok(_response);
        }

        [HttpPost]
        [Route("addEmployee")]
        public async Task<IActionResult> AddEmployeeAsync(Employee employee)
        {
            var _response = await _employeeService.AddEmployeeAsync(employee);
            return Ok(_response);
        }

        [HttpPut]
        [Route("updateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(Employee employee)
        {
            var _response = await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(_response);
        }

        [HttpDelete]
        [Route("deleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
        {
            var _response = await _employeeService.DeleteEmployeeAsync(employeeId);
            return Ok(_response);
        }
    }
}
