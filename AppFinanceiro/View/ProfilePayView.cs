using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.View.Models
{
    public class ProfilePayView
    {
        public Guid Id { get; set; }
        public Guid IdExpanse { get; set; }
        public Guid IdTypePay { get; set; }
        public int Parcel { get; set; }
        public DateTime DueDate { get; set; }
        public virtual IEnumerable<ExpenseView> Expense { get; set; }
        public virtual TypePayView TypePay { get; set; }
    }
}
