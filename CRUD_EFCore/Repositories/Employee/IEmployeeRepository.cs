using CRUD_EFCore.Models;
using CRUD_EFCore.Models.Employees;

namespace CRUD_EFCore.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        Task<APIResponse<List<Employee>>> GetAllEmployeesAsync();
        Task<APIResponse<Employee>> GetEmployeeByIdAsync(int employeeId);
        Task<APIPostResponse> AddEmployeeAsync(Employee employee);
        Task<APIPostResponse> UpdateEmployeeAsync(Employee employee);
        Task<APIPostResponse> DeleteEmployeeAsync(int employeeId);
    }
}
