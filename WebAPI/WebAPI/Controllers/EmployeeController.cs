using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CompanyService.Interfaces;
using System.Collections.Generic;

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
        public JsonResult Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (_employeeService.AddEmployee(emp))
                {
                    return new JsonResult("Added Successfully");
                }
            }
            return new JsonResult("Something went wrong, Please try again");
        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (_employeeService.UpdateEmployee(emp))
                {
                    return new JsonResult("Updated Successfully");
                }
            }
            return new JsonResult("Something went wrong, Please try again");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int? id)
        {
            if (id != null)
            {
                if (_employeeService.DeleteEmployee(id))
                {
                    return new JsonResult("Deleted Successfully");
                }
            }
            return new JsonResult("Something went wrong, Please try again");
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
