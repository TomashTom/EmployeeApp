using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class EmployeeCommands
    {
        public static async Task SetEmployeeAsync(string idString, string name, string salaryString, AppDbContext context)
        {
            try
            {
                int employeeId = int.Parse(idString);
                decimal employeeSalary = decimal.Parse(salaryString);

                var employee = await context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    employee = new Employee { EmployeeId = employeeId };
                    context.Employees.Add(employee);
                }

                employee.EmployeeName = name;
                employee.EmployeeSalary = Convert.ToInt32(employeeSalary);


                await context.SaveChangesAsync();
                Console.WriteLine($"Employee {name} with ID {employeeId} and Salary {employeeSalary} has been saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static async Task GetEmployeeAsync(string idString, AppDbContext context)
        {
            try
            {
                int employeeId = int.Parse(idString);

                var employee = await context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.EmployeeName}, Salary: {employee.EmployeeSalary}");
                }
                else
                {
                    Console.WriteLine($"Employee with ID {employeeId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
