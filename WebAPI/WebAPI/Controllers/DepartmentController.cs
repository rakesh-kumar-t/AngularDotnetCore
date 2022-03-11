using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using CompanyService.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly CompanyDBContext _companyDB;
        private readonly IDepartmentService _deptService;

        public DepartmentController( CompanyDBContext companyDB,IDepartmentService deptService)
        {
            _companyDB = companyDB;
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
        public async Task<IActionResult> Post(Department dep)
        {
            if (ModelState.IsValid)
            {
                var res = await _deptService.AddDepartment(dep);
                if(res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Department added successfully" });
                }

            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(Department dep)
        {
            if (ModelState.IsValid)
            {
                var res = await _deptService.UpdateDepartment(dep);
                if (res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Department Updated successfully" });
                }
            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var res = await _deptService.DeleteDepartment(id);
                if(res)
                {
                    return Ok(new { status = StatusCodes.Status200OK, success = true, data = "Department Deleted successfully" });

                }
            }
            return BadRequest(new { status = StatusCodes.Status400BadRequest, success = false, data = "Something went wrong, Please try again" });

        }
    }
}
