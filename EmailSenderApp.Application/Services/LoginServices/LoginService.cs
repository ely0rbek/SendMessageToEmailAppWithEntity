using EmailSenderApp.Domain.Entites.Models;
using EmailSenderApp.Infrastructure.Repositories.RegisterRepositories;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using EmailSenderApp.Infrastructure.Repositories.LoginRepositories;

namespace EmailSenderApp.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IConfiguration _config;
        private readonly ILoginRepository _loginRepository;
        public LoginService(IRegisterRepository registerRepository, IConfiguration config, ILoginRepository loginRepository)
        {
            _registerRepository = registerRepository;
            _config = config;
            _loginRepository = loginRepository;
        }

        public async Task<string> LoginAsync(BaseEmailModel baseModel)
        {
            if(await _registerRepository.IsUserValid(baseModel.Email))
            {
                try
                {
                    var OneUsedKey = Guid.NewGuid().ToString();
                    var emailSettings = _config.GetSection("EmailSettings");
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                        Subject = "Your Access Code",
                        Body = OneUsedKey,
                    };
                    mailMessage.To.Add(baseModel.Email);

                    using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
                    {
                        Port = Convert.ToInt32(emailSettings["MailPort"]),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                        EnableSsl = true,
                    };

                    await smtpClient.SendMailAsync(mailMessage);

                    var newChecking = new CheckingModel()
                    {
                        Email = baseModel.Email,
                        SendedCode = OneUsedKey
                    };
                    if (await _loginRepository.IsUserAsync(baseModel.Email))
                    {
                        await _loginRepository.UpdateCheckingModel(newChecking);
                    }
                    else
                    {
                        await _loginRepository.CreateCheckingModel(newChecking);
                    }

                    return "Code was sent to your email!";
                }
                catch (Exception ex)
                {
                    return $"Error was found:{ex.Message}";
                }
            }
            else { return "You must register first."; }
        }
    }
}
