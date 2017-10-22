using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notas_Util
{
    public class LoginService
    {
        public static Task<bool> LoginAsync(string username, string password)
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return (username.ToLower() == "Altamir".ToLower() && password == "12345");
            });
        }
    }
}
