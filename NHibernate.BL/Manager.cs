using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Domain;
using NHibernate.DAL;

namespace NHibernate.BL
{
    public class Manager : IManager
    {
        private IRepository repo;

        public Manager()
        {
            repo = new Repository();
        }

        public void AddLoLAccount(LoLAccount AccountToAdd)
        {
            repo.AddLoLAccount(AccountToAdd);
        }

        public void ChangeName(LoLAccount AccountToUpdate)
        {
            repo.UpdateName(AccountToUpdate);
        }

        public void DeleteAccount(LoLAccount AccountToDelete)
        {
            repo.DeleteAccount(AccountToDelete);
        }

        public LoLAccount ReadAccount(int id)
        {
            return repo.GetLoLAccount(id);
        }

        public IEnumerable<LoLAccount> ReadAllAccounts()
        {
            return repo.GetAllAccounts();
        }
    }
}
