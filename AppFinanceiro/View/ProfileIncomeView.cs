using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class ProfileIncomeView
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdIncome { get; set; }
        public virtual UserView User { get; set; }
        public virtual IncomeView Income { get; set; }
    }
}
