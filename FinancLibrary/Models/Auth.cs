using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class Auth
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AutorizeName { get; set; }
        public virtual ICollection<UserAuth> UserAuth { get; set; }
    }
}
