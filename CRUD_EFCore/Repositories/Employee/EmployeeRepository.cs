using Azure;
using CRUD_EFCore.Data;
using CRUD_EFCore.Models;
using CRUD_EFCore.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD_EFCore.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<APIResponse<List<Employee>>> GetAllEmployeesAsync()
        {
            APIResponse<List<Employee>>? _response = null;
            try
            {
                var employees = await _appDbContext.Employee.Where(X => X.IsActive == true).ToListAsync();
                _response = new APIResponse<List<Employee>>
                {
                    IsSuccess = true,
                    Message = "Employees retrieved successfully",
                    Data = employees
                };
            }
            catch (Exception ex)
            {
                _response = new APIResponse<List<Employee>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = []
                };
            }
            return _response;
        }
        public async Task<APIResponse<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            APIResponse<Employee>? _response = null;
            try
            {
                var employees = await _appDbContext.Employee.FindAsync(employeeId);
                _response = new APIResponse<Employee>
                {
                    IsSuccess = true,
                    Message = "Employees retrieved successfully",
                    Data = employees
                };
            }
            catch (Exception ex)
            {
                _response = new APIResponse<Employee>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
            return _response;
        }
        public async Task<APIPostResponse> AddEmployeeAsync(Employee employee)
        {
            APIPostResponse? _response = new APIPostResponse();
            if (employee != null)
            {
                employee.IsActive = true;
                employee.InsertDate = DateTime.Now.Date;
                await _appDbContext.Employee.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();

                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee added successfully."
                };
            }
            else {
                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee details missing."
                };
            }
            return _response;
        }
        public async Task<APIPostResponse> UpdateEmployeeAsync(Employee employee)
        {
            APIPostResponse? _response = new APIPostResponse();
            var _employee = await _appDbContext.Employee.FindAsync(employee.EmployeeId);
            if (_employee != null)
            {
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
                _employee.Email = employee.Email;
                _employee.Department = employee.Department;
                _employee.Salary = employee.Salary;
                await _appDbContext.SaveChangesAsync();

                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee details updated successfully."
                };
            }
            else
            {
                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee details missing."
                };
            }
            return _response;
        }
        public async Task<APIPostResponse> DeleteEmployeeAsync(int employeeId)
        {
            APIPostResponse? _response = new APIPostResponse();
            var _employee = await _appDbContext.Employee.FindAsync(employeeId);
            if (_employee != null)
            {
                _employee.IsActive = false;
                await _appDbContext.SaveChangesAsync();

                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee details updated successfully."
                };
            }
            else {
                _response = new APIPostResponse
                {
                    IsSuccess = true,
                    Message = "Employee details updated successfully."
                };
            }
            return _response;
        }
    }
}
