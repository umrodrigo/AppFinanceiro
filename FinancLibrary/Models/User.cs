using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid IdUserAuth { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public int Region { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual ICollection<ProfileIncome> ProfileIncome { get; set; }
        public virtual ICollection<ProfileExpense> ProfileExpense { get; set; }
        public virtual ICollection<UserAuth> UserAuth { get; set; }
    }
}
