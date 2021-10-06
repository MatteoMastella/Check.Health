using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class Response
    {
        public bool Executed { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }


    }
}
