using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Models
{
    public class CrearUsuario
    {
        public int usIdC { get; set; } 
        public string usName { get; set; }
        public string usSName { get; set; }
        public string usLastName { get; set; }
        public string usSLastName { get; set; }
        public string usEmail { get; set; }
        public string usPass { get; set; }
        public string usTel { get; set; }
    }
}
