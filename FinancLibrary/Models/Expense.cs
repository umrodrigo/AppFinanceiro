using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class Expense
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
        public virtual ProfileExpense ProfileExpense { get; set; }
        public virtual Origin Origin { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProfilePay ProfilePay { get; set; }
    }
}
