﻿namespace Sm.Crm.Application.Exceptionss
{
    public class NotFoundUserExceptions:Exception
    {
        public NotFoundUserExceptions()
        {
        }

        public NotFoundUserExceptions(string? message) : base("Kullanıcı adı veya şifre hatalı")
        {
        }

        public NotFoundUserExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
