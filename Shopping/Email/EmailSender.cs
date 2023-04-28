using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Shopping.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridKey);
            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("m.albiononlinex@gmail.com", "ShoppingApp"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            mesaj.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(mesaj);
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        public EmailOptions Options { get; set; }
        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }
    }
}
