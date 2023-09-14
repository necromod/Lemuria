using Lemuria.DTO;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Lemuria.BLL
{
    public class EmailBLL
    {
        public void EnviarEmail(MensagemDTO mensagem)
        {
            //preparar o conteudo do email
            string body = "";
            body += "<b>Nome: </b> " + mensagem.Nome + "<br>";
            body += "<b>E-mail: </b> " + mensagem.Email + "<br>";
            body += "<b>Mensagem: </b> " + mensagem.Mensagem + "<br>";
            body += "<b>Data do Envio: </b> " + DateTime.Now.ToString("dd/MM/yy hh:mm");

            //Preparar o e-mail (mensagem) a ser enviado
            MailMessage msg = new MailMessage();
            //Remetente
            msg.From = new MailAddress(mensagem.Email, mensagem.Nome);
            //Destinatário
            msg.To.Add(new MailAddress("profronicosta@gmail.com"));
            //Assunto
            msg.Subject = "Contato via site - " + mensagem.Nome;
            //Corpo do E-mail
            msg.Body = body;
            //Indica que a msg é html
            msg.IsBodyHtml = true;


            //configura o servidor SMTP
            SmtpClient smtp = new SmtpClient();
            //dados do servidor de e-mail
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("profronicosta@gmail.com", "cqoyeaaqiuyxyrrx");

            //Fazer o envio
            try
            {
                smtp.Send(msg);
            }
            catch (Exception erro)
            {
               throw new Exception(erro.Message);
            }
        }

    }
}