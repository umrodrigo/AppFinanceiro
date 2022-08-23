﻿using Financ.Data.Models;
using Financ.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Clients
{
    public class UserRep
    {
        private readonly IRepository<User> repo;
        public UserRep(FinancContext context)
        {
            repo = new GenericRepository<User>(context);
        }

        public User Save(User instance)
        {
            try
            {
                if(instance.Id == Guid.Empty)
                    Insert(instance);
                else
                    Update(instance);
                return instance;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(User instance)
        {
            instance.CreatedAt = DateTime.Now;
            instance.UpdateAt = instance.CreatedAt;
            repo.Add(instance);
        }

        public void Update(User instance)
        {
            instance.UpdateAt = DateTime.Now;
            repo.Update(instance);
        }
        public void Delete(User instance)
        {
            repo.Delete(instance);
        }
        public Task<List<User>> GetAll()
        {
            return repo.Query.ToListAsync();
        }
        public Task<List<User>> Get(int pageIndex, int pageSize, string search)
        {
            var qr = repo.Query;

            if (!String.IsNullOrEmpty(search))
                qr = qr.Where(z => EF.Functions.Like(z.Name, $"%{search}%"));

            return qr
                .OrderBy(z => z.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public Task<User> GetById(Guid id)
        {
            return repo
                .FirstOrDefaultAsync(x => x.Id == id, 
                    include: inc => inc
                                    .Include(x => x.ProfileIncome)
                                    .ThenInclude(x => x.Income)
                                    .Include(x => x.ProfileExpense)
                                    .ThenInclude(x => x.Expense));
        }
    }
}
