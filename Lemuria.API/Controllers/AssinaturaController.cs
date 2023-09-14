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
    public class AssinaturaController : ControllerBase
    {
        // GET: api/<AssinaturaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                AssinaturaDAL assinaturaDAL = new AssinaturaDAL();
                var assinaturas = assinaturaDAL.Listar();
                return Ok(assinaturas);
            }
            catch
            {
                return BadRequest("Erro ao listar");
            }
        }

        // GET api/<AssinaturaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                AssinaturaDAL assinaturaDAL = new AssinaturaDAL();
                var assinatura = assinaturaDAL.Selecionar(id);
                return Ok(assinatura);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao Selecionar!");
            }
        }

        // POST api/<AssinaturaController>
        [HttpPost]
        public ActionResult Post([FromBody] AssinaturaDTO assinatura)
        {
            try
            {
                if (assinatura == null)
                    return BadRequest("Os dados da assinatura não foram informado");

                //validação se o plano Existe
                PlanoDAL planoDAL = new PlanoDAL();
                var planoInformado = planoDAL.Selecionar(assinatura.IdPlano);
                if (planoInformado.Nome == null) 
                    return BadRequest("O IdPlano informado não existe no cadastro de Plano");

                //comentei, pq estou pegando a data automatica na DAL
                //assinatura.DataAssinatura = DateTime.Now;

                AssinaturaDAL assinaturaDAL = new AssinaturaDAL();
                assinaturaDAL.Cadastrar(assinatura);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao cadastrar Assinatura");
            }
        }

        // PUT api/<AssinaturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AssinaturaDTO assinatura)
        {
            try
            {
                //validação se o plano Existe
                PlanoDAL planoDAL = new PlanoDAL();
                var planoInformado = planoDAL.Selecionar(assinatura.IdPlano);
                if (planoInformado.Nome == null)
                    return BadRequest("O IdPlano informado não existe no cadastro de Plano");

                assinatura.Id = id;
                AssinaturaDAL assinaturaDAL = new AssinaturaDAL();
                assinaturaDAL.Editar(assinatura);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao Editar");
            }
        }

        // DELETE api/<AssinaturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                AssinaturaDAL assinaturaDAL = new AssinaturaDAL();
                assinaturaDAL.Deletar(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Erro ao Excluir!");
            }
        }
    }
}
