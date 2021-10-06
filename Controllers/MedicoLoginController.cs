using System;
using System.Collections.Generic;
using System.Linq;
using SiteSaúde.Models;
using System.Threading.Tasks;

namespace SiteSaúde.Controllers
{
    public class MedicoLoginController
    {
        public static Response CheckerSelect(string email, string senha, out MedicoLogin medico)
        {
            medico = new MedicoLogin();

            if (!string.IsNullOrEmpty(email) && email.Length < 51)
            {
                if (!string.IsNullOrEmpty(senha) && senha.Length < 51)
                {
                    return MedicoLoginBD.Select(email, senha, out medico);
                }
                else
                {
                    return new Response
                    {
                        Executed = false,
                        ErrorMessage = "Senha está incorreta"
                    };
                }
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "E-mail está incorreto"
                };
            }

        }
    }
}
