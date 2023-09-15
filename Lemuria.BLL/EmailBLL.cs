using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Lemuria.DTO;



namespace Lemuria.BLL
{
    public class EmailBLL
    {
        public void EnviarEmail(MensagemDTO mensagem)
        {
            //Preparar conteúdo do email
            string body = "";
            body += "<b>Nome: </b> " + mensagem.Nome + "<br>";
            body += "<b>E-mail: </b> " + mensagem.Email + "<br>";
            body += "<b>Mensagem: </b> " + mensagem.Mensagem + "<br>";
            body += "<b>Data do Envio: </b> " + DateTime.Now.ToString("dd/mm/yy hh:mm");

            //criar mensagem email
            MailMessage msg = new MailMessage();
            //Remetente
            msg.From = new MailAddress(mensagem.Email, mensagem.Email);
            //Destinarário
            msg.To.Add(new MailAddress("forteamsenac@outlook.com"));
            //Assunto
            msg.Subject = "Contato via site - " + mensagem.Nome;
            //Corpo do email
            msg.Body = body;
            //Indica que a msg é thml
            msg.IsBodyHtml = true;

            //Configurar servidor SMPT
            SmtpClient smtp = new SmtpClient();
            //dados do servidor de e-mail
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("forteamsenac@outlook.com", "ifwdalfmnjanwuaa");

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