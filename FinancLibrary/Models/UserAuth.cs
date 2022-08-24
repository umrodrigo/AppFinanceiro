using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdAuth { get; set; }
        public virtual User User { get; set; }
        public virtual Auth Auth { get; set; }
    }
}
