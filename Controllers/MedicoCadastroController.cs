using System;
using System.Collections.Generic;
using System.Linq;
using SiteSaúde.Models;
using System.Threading.Tasks;

namespace SiteSaúde.Controllers
{
    public class MedicoCadastroController
    {
        public static Response CheckerInsert(MedicoCadastro medico)
        {
            if (!string.IsNullOrEmpty(medico.Nome) && medico.Nome.Length < 51)
            {
                if (!string.IsNullOrEmpty(medico.Cpf) && medico.Cpf.Length < 12)
                {
                    if (!string.IsNullOrEmpty(medico.Email) && medico.Email.Length < 51)
                    {
                        if (!string.IsNullOrEmpty(medico.Senha) && medico.Senha.Length < 51)
                        {
                            if (!string.IsNullOrEmpty(medico.Tel) && medico.Tel.Length < 12)
                            {
                                 if  (!string.IsNullOrEmpty(medico.Especialidade) && medico.Especialidade.Length < 51)
                                {
                                    return MedicoCadastroBD.Insert(medico);
                                }
                                else
                                {
                                    return new Response
                                    {
                                        Executed = false,
                                        ErrorMessage = "Especialidade num padrão incorreto"
                                    };
                                }
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
