using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;
using Web.Models.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    { 
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var allEmployees = dbContext.Employees.ToList();
                return Ok(allEmployees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Cannot fetch employees.", Details = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = dbContext.Employees.Find(id);
                if (employee is null)
                {
                    return NotFound(new { Message = "Employee not found." });
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Cannot fetch employees.", Details = ex.Message });
            }
        }

        
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeID }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }



        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = dbContext.Employees.Find(id);
                if (employee is null)
                {
                    return NotFound(new { Message = "Employee not found." });
                }

                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Email = updatedEmployee.Email;
                employee.PhoneNumber = updatedEmployee.PhoneNumber;
                employee.HireDate = updatedEmployee.HireDate;
                employee.JobTitle = updatedEmployee.JobTitle;
                employee.DepartmentID = updatedEmployee.DepartmentID;
                employee.Salary = updatedEmployee.Salary;

                dbContext.SaveChanges();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Cannot update employee details.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                
                var employee = dbContext.Employees.AsNoTracking().FirstOrDefault(e => e.EmployeeID == id);

                if (employee is null)
                {
                    
                    return NotFound(new { Message = "Employee not found." });
                }

               
                dbContext.Employees.Attach(employee);
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();

                return Ok(new { Message = "Employee deleted." });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Message = "Cannot delete the employees.", Details = ex.Message });
            }
        }

        

    }
}
