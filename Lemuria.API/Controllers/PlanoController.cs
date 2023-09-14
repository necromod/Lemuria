using Lemuria.DAL;
using Lemuria.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lemuria.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class PlanoController : ControllerBase
    {
        // GET: api/<PlanoController>

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                PlanoDAL planoDAL = new PlanoDAL();
                var planos = planoDAL.Listar();
                return Ok(planos);
            }
            catch
            {
                return BadRequest("Erro ao listar");
            }
        }


        // GET api/<PlanoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try 
            {
                PlanoDAL planoDAL = new PlanoDAL();
                var plano = planoDAL.Selecionar(id);
                return Ok(plano);
            }
            catch 
            {
                return BadRequest("Erro ao selecionar");
            }
        }

        // POST api/<PlanoController>
        [HttpPost]
        public ActionResult Post([FromBody] PlanoDTO plano)
        {
            try
            {
                if (plano == null)
                    return BadRequest("Os dados do plano não foram informado");
                
                PlanoDAL planoDAL = new PlanoDAL();
                planoDAL.Cadastrar(plano);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao cadastrar Plano");
            }
        }

        // PUT api/<PlanoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlanoDTO plano)
        {
            try
            {
                plano.Id = id;
                PlanoDAL planoDAL = new PlanoDAL();
                planoDAL.Editar(plano);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao Editar");
            }
        }

        // DELETE api/<PlanoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                PlanoDAL planoDAL = new PlanoDAL();
                planoDAL.Excluir(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao Excluir!");
            }
        }
    }
}
