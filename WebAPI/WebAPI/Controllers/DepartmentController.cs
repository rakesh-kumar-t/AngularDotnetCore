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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private CompanyDBContext companyDB=new CompanyDBContext();

        [HttpGet]
        public JsonResult Get()
        {
            var departments = companyDB.Departments.ToList();

            return new JsonResult(departments);

        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            if (ModelState.IsValid)
            {
                companyDB.Departments.Add(dep);
                var result=companyDB.SaveChanges();
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
                companyDB.Entry(dep).State = EntityState.Modified;
                var result=companyDB.SaveChanges();
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
                var department = companyDB.Departments.Find(id);
                if (department != null)
                {
                    companyDB.Departments.Remove(department);
                    var result=companyDB.SaveChanges();
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
