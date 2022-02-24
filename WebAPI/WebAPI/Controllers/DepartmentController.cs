using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly WorkDBContext _workDB;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IWebHostEnvironment env, WorkDBContext workDB)
        {
            _env = env;
            _workDB = workDB;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var departments = _workDB.Departments.ToList();

            return new JsonResult(departments);

        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            if (ModelState.IsValid)
            {
                _workDB.Departments.Add(dep);
                var result=_workDB.SaveChanges();
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
                _workDB.Entry(dep).State = EntityState.Modified;
                var result=_workDB.SaveChanges();
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
                var department = _workDB.Departments.Find(id);
                if (department != null)
                {
                    _workDB.Departments.Remove(department);
                    var result=_workDB.SaveChanges();
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
