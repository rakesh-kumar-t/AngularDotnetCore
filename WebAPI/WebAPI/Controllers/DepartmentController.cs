using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using CompanyService.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly WorkDBContext _workDB;
        private readonly IWebHostEnvironment _env;
        private readonly IDepartmentService _deptService;

        public DepartmentController(IWebHostEnvironment env, WorkDBContext workDB,IDepartmentService deptService)
        {
            _env = env;
            _workDB = workDB;
            _deptService = deptService;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            var departments = await _deptService.GetAllDepartments();

            return departments;

        }
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id != null)
            {
                var department = _deptService.GetDepartment(id);
                return Ok(department);
            }
            return null;
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            if (ModelState.IsValid)
            {
                if(_deptService.AddDepartment(dep))
                {
                    return new JsonResult("Added Successfully");
                }

            }
            return new JsonResult("Something went wrong, Please try again");
            
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            if (ModelState.IsValid)
            {
                if (_deptService.UpdateDepartment(dep))
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
                if(_deptService.DeleteDepartment(id))
                {
                    return new JsonResult("Deleted Successfully");
                }
            }
            return new JsonResult("Something went wrong, Please try again");
        }
    }
}
