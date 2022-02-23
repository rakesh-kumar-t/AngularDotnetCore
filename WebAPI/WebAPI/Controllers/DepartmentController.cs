using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CompanyDBContext _companyDB;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IWebHostEnvironment env, CompanyDBContext companyDB)
        {
            _env = env;
            _companyDB = companyDB;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var departments = _companyDB.Departments.ToList();

            return new JsonResult(departments);

        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            if (ModelState.IsValid)
            {
                _companyDB.Departments.Add(dep);
                var result=_companyDB.SaveChanges();
                if (result > 0)
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
                _companyDB.Entry(dep).State = EntityState.Modified;
                var result=_companyDB.SaveChanges();
                if (result > 0)
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
                var department = _companyDB.Departments.Find(id);
                if (department != null)
                {
                    _companyDB.Departments.Remove(department);
                    var result=_companyDB.SaveChanges();
                    if(result > 0)
                    {
                        return new JsonResult("Deleted Successfully");
                    }
                }
            }
            return new JsonResult("Something went wrong, Please try again");
        }
    }
}
