using Financ.Data.Models;
using Financ.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Clients
{
    public class UserRep
    {
        private readonly IRepository<User> repo = null;
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

        private void Insert(User instance)
        {
            repo.Update(instance);
        }

        private void Update(User instance)
        {
            repo.Add(instance);
        }
        private void Delete(User instance)
        {
            repo.Delete(instance);
        }
    }
}
