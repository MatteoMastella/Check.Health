using System;
using SiteSaúde.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Controllers
{
    public class UsuarioCadastroController
    {
        public static Response CheckerInsert(UsuarioCadastro user)
        {
            if(!string.IsNullOrEmpty(user.Nome) && user.Nome.Length < 51)
            {
                if(!string.IsNullOrEmpty(user.Cpf) && user.Cpf.Length < 12)
                {
                    if(!string.IsNullOrEmpty(user.Email) && user.Email.Length < 51)
                    {
                        if(!string.IsNullOrEmpty(user.Senha) && user.Senha.Length < 51)
                        {
                            if(!string.IsNullOrEmpty(user.Tel) && user.Tel.Length < 12)
                            {
                                return UsuarioCadastroBD.Insert(user);
                            }
                            else
                            {
                                return new Response
                                {
                                    Executed = false,
                                    ErrorMessage = "Número de telefone num padrão incorreto"
                                };
                            }
                        }
                        else
                        {
                            return new Response
                            {
                                Executed = false,
                                ErrorMessage = "Senha num padrão incorreto"
                            };
                        }
                    }
                    else
                    {
                        return new Response
                        {
                            Executed = false,
                            ErrorMessage = "E-mail num padrão incorreto"
                        };
                    }
                }
                else
                {
                    return new Response
                    {
                        Executed = false,
                        ErrorMessage = "CPF num padrão incorreto"
                    };
                }
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "Nome num padrão incorreto"
                };
            }
        }

    }
}
