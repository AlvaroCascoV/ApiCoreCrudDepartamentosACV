using ApiCoreCrudDepartamentosACV.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentosACV.Data
{
    public class DepartamentosContext:DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options){}
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
