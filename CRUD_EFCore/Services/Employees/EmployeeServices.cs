using CRUD_EFCore.Models;
using CRUD_EFCore.Models.Employees;
using CRUD_EFCore.Repositories.Employees;

namespace CRUD_EFCore.Services.Employees
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository){
            _employeeRepository = employeeRepository;
        }

        public async Task<APIResponse<List<Employee>>> GetAllEmployeesAsync()        
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<APIResponse<Employee>> GetEmployeeByIdAsync(int employeeId) 
        { 
            return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
        }

        public async Task<APIPostResponse> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<APIPostResponse> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task<APIPostResponse> DeleteEmployeeAsync(int employeeId)
        {
            return await _employeeRepository.DeleteEmployeeAsync(employeeId);
        }
    }
}
