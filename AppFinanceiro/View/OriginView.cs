using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.View.Models
{
    public class OriginView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<IncomeView> Income { get; set; }
        public virtual IEnumerable<ExpenseView> Expense { get; set; }
    }
}
