using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAccess.Models;
using DataAccess.Context;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly WorkDBContext _workDB;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IWebHostEnvironment env,WorkDBContext workDB)
        {
            _env = env;
            _workDB = workDB;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var employees = _workDB.Employees.Include(emp=>emp.Department).ToList();

            return new JsonResult(employees);
        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _workDB.Employees.Add(emp);
                var result = _workDB.SaveChanges();
                if (result > 0)
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
                _workDB.Entry(emp).State = EntityState.Modified;
                var result = _workDB.SaveChanges();
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
                var employee = _workDB.Employees.Find(id);
                if (employee != null)
                {
                    _workDB.Employees.Remove(employee);
                    var result = _workDB.SaveChanges();
                    if (result > 0)
                    {
                        return new JsonResult("Deleted Successfully");
                    }
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
