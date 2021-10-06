using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class MedicoCadastro
    {
        public string IdMedico { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tel { get; set; }
        public string Especialidade { get; set; }
        
    }
}
