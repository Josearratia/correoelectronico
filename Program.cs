using System;
using System.Net;
using System.Net.Mail;

namespace EnviarCorreo
{
    class Program
    {   
        
        static void enviar(){
            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            email.To.Add(new MailAddress("jesus.antoniomiravete@gmail.com"));
            email.From = new MailAddress("correopruebapollo@gmail.com");
            email.Subject = "Reporte diario";
            email.Body = "Correo de prueba";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;   

            
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("correopruebapollo@gmail.com","pollito_M2");

            string output = null;

            try{
                smtp.Send(email);
                email.Dispose();
                output = "Si se envia el correo";
            }
            catch (Exception ex)
            {
                output = "No se envia: "+ex.StackTrace;
            }
            Console.WriteLine(output);
        }
    

    static void Main(string[] args)
        {
            enviar();
        }
    }
}
