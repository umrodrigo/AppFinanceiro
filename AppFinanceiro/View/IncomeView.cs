using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.View.Models
{
    public class IncomeView
    {
        public Guid Id { get; set; }
        public Guid IdOrigin { get; set; }
        public double Cust { get; set; }
        public DateTime Date { get; set; }
        public bool Recurrent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual ProfileIncomeView ProfileIncome { get; set; }
        public virtual OriginView Origin { get; set; }
    }
}
