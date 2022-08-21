using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class TypePayView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int flag { get; set; }
        public virtual IEnumerable<ProfilePayView> ProfilePay { get; set; }
    }
}
