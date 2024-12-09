using WebApiDemo.Data;
using WebApiDemo.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAppiDemo.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly ApplicationDbContext db;
        public EmployeeService(ApplicationDbContext db)
        {

            this.db = db;

        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await db.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Role = updatedEmployee.Role;
                employee.DateOfJoining = updatedEmployee.DateOfJoining;
                employee.Manager = updatedEmployee.Manager;

                await db.SaveChangesAsync();
            }

            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }

            return employee;
        }
    }
}
    
