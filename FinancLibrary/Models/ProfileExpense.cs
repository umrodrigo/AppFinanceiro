using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class ProfileExpense
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdExpense { get; set; }
        public virtual User User { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
