using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmplDBA.API.Data;
using EmplDBA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmplDBA.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        DataContext db;
        public EmployeesController(DataContext context)
        {
            db = context;
            if (!db.Employees.Any())
            {
                db.Employees.Add(new Employee { Name = "Ivan", Surname="Ivanov", Age = 25, PostID = 1});
                db.Employees.Add(new Employee { Name = "Petr", Surname="Petrov", Age = 35, PostID = 2 });
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await db.Employees.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            Employee employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }
 
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
 
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
 
        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!db.Employees.Any(x => x.EmployeeID == employee.EmployeeID))
            {
                return NotFound();
            }
 
            db.Update(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
 
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}