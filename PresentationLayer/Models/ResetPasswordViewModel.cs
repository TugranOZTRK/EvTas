﻿namespace PresentationLayer.Models
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
    }
}
