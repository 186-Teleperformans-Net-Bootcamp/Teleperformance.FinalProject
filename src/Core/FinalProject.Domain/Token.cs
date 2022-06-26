using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime TokenLifeTime{ get; set; }
    }
}
