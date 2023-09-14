using Lemuria.BLL;
using Lemuria.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lemuria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] MensagemDTO mensagem)
        {
            EmailBLL emailBLL = new EmailBLL();

            try
            {
                emailBLL.EnviarEmail(mensagem);
                return Ok("E-mail enviado com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao Enviar!");
            }
        }

    }
}
