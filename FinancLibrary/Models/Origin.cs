using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class Origin
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<Income> Income { get; set; }
        public virtual IEnumerable<Expense> Expense { get; set; }
    }
}
