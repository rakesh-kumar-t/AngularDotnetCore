using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CompanyService.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly  IEmployeeService _employeeService;

        public EmployeeController(IWebHostEnvironment env,IEmployeeService employeeService)
        {
            _env = env;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _employeeService.GetAllEmployees();

            return employees;

        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var res = await _employeeService.AddEmployee(emp);
                if (res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Employee Added successfully" });
                }
            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var res = await _employeeService.UpdateEmployee(emp);
                if (res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Employee Updated successfully" });
                }
            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var res = await _employeeService.DeleteEmployee(id);
                if (res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Employee Deleted successfully" });
                }
            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });

        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
                
                using(var stream=new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);

            }
            catch
            {
                return new JsonResult("anonymus.png");
            }
        }

    }
}
