using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class MedicoLogin
    {
        public int IdMedico { get;  set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
