using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Context
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
