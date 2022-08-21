using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.View.Models
{
    public class ExpenseView
    {
        public Guid Id { get; set; }
        public Guid IdCategory { get; set; }
        public Guid IdOrigin { get; set; }
        public Guid IdProfilePay { get; set; }
        public double Cust { get; set; }
        public DateTime Date { get; set; }
        public bool Recurrent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual ProfileExpenseView ProfileExpense { get; set; }
        public virtual OriginView Origin { get; set; }
        public virtual CategoryView Category { get; set; }
        public virtual ProfilePayView ProfilePay { get; set; }
    }
}
