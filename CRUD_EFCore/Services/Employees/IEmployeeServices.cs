using CRUD_EFCore.Models;
using CRUD_EFCore.Models.Employees;
using System.Threading.Tasks;

namespace CRUD_EFCore.Services.Employees
{
    public interface IEmployeeServices
    {
        Task<APIResponse<List<Employee>>> GetAllEmployeesAsync();
        Task<APIResponse<Employee>> GetEmployeeByIdAsync(int employeeId);
        Task<APIPostResponse> AddEmployeeAsync(Employee employee);
        Task<APIPostResponse> UpdateEmployeeAsync(Employee employee);
        Task<APIPostResponse> DeleteEmployeeAsync(int employeeId);
    }
}
