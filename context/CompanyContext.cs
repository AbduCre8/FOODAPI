using Microsoft.EntityFrameworkCore;
using WebAPIPractise.Models;

namespace WebAPIPractise.Context
{

    public class CompanyContext
        : DbContext
    {
        public CompanyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}