using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Api.View.Models
{
    public class CategoryView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<ExpenseView> Expense { get; set; }
    }
}
