﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<Expense> Expense { get; set; }
    }
}
