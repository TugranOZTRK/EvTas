using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using PresentationLayer.Models;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace PresentationLayer.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Post = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = token }, Request.Scheme);
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("EvTaş Admin", "tugranozturk7@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    string htmlBody = @"
                    <!DOCTYPE html>
                    <html lang=""tr"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Parolamı Sıfırla</title>
                    </head>
                    <body style=""font-family: Arial, sans-serif; background-color: #f0f0f0;"">
                        <div class=""container"" style=""width: 350px; padding: 20px; margin: 50px auto; background-color: #fff; box-shadow: 0px 0px 5px 0px rgba(0,0,0,0.1);"">
                            <h1 style=""text-align: center; margin-bottom: 20px;"">Parolamı Sıfırla</h1>
                            <p style=""margin: 15px;"">Şifreni yenilemek için aşağıdaki butona tıkla.</p>
                            <form style=""display: flex; flex-direction: column;"">
                                <a href=""{resetPasswordLink}"" style=""margin-top: 10px; padding: 10px; background-color: #0145ff; color: #fff; border: none; border-radius: 10px; cursor: pointer; text-decoration: none; text-align: center;"">Parolamı Sıfırla</a>
                            </form>
                        </div>
                    </body>
                    </html>";

                    bodyBuilder.HtmlBody = htmlBody;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "EvTaş Parola Sıfırlama";
                    
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("tugranozturk7@gmail.com", "xyuczipoilapffky");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.");
                    return View(model);
                }

            }
            ModelState.AddModelError(string.Empty, "Geçerli bir e-posta adresi girin.");
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string code)
        {
            // Kullanıcı kimliği veya şifre sıfırlama kodu geçerli değilse, hata sayfasına yönlendir
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Error"); // Hata sayfasını oluşturmanız gerekebilir
            }

            var model = new ResetPasswordViewModel
            {
                UserId = userId,
                Code = code
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                    return View(model);
                }

                // Şifre sıfırlama işlemini gerçekleştir
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Account"); // Şifre sıfırlama başarılı sayfasına yönlendir
                }

                // Şifre sıfırlama işlemi başarısız oldu
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
