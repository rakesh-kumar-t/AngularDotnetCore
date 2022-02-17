using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private CompanyDBContext companyDB=new CompanyDBContext();
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var employees = companyDB.Employees.ToList();

            return new JsonResult(employees);
        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                companyDB.Employees.Add(emp);
                var result = companyDB.SaveChanges();
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
                companyDB.Entry(emp).State = EntityState.Modified;
                var result = companyDB.SaveChanges();
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
                var employee = companyDB.Employees.Find(id);
                if (employee != null)
                {
                    companyDB.Employees.Remove(employee);
                    var result = companyDB.SaveChanges();
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

        //[Route("GetAllDepartmentNames")]
        //public JsonResult GetAllDepartmentNames()
        //{
        //    string query = @"
        //                    select DepartmentName from dbo.Department";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult(table);

        //}
    }
}
