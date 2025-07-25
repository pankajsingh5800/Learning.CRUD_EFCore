namespace CRUD_EFCore.Models.Employees
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Department { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
