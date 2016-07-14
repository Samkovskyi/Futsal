using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Futsal.Business.Entities
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public String Logo { get; set; }
    }
}
