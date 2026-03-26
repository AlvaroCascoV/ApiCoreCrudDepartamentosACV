using ApiCoreCrudDepartamentosACV.Data;
using ApiCoreCrudDepartamentosACV.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentosACV.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }

        public async Task CreateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento = id;
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = await FindDepartamentoAsync(id);
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento dept = await FindDepartamentoAsync(id);
            this.context.Departamentos.Remove(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
