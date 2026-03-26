using ApiCoreCrudDepartamentosACV.Models;
using ApiCoreCrudDepartamentosACV.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentosACV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repo.GetDepartamentosAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }
        
        //LOS METODOS POR DEFECTO, POR EJEMPLO, POST, RECIBEN
        //UN OBJETO. SI NECESITAMOS PERSONALIZARLOS, DEBEMOS
        //UTILIZAR ROUTING
        [HttpPost]
        public async Task<ActionResult> Post(Departamento departamento)
        {
            await this.repo.CreateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //CREAMOS OTRO METODO PARA INSERTAR CON ROUTING
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> Create(int id, string nombre, string localidad)
        {
            await this.repo.CreateDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //EN LOS METODOS PUT, TAMBIEN PODRIAMOS RECIBIR EL ID
        //A MODIFICAR.
        //SI RECIBIMOS PARAMETROS, EL OBJETO ES EL ULTIMO EN DECLARARSE
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Update(int id, Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(id, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }
    }
}
