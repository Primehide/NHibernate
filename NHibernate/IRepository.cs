using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Domain;

namespace NHibernate.DAL
{
    public interface IRepository
    {
        IEnumerable<LoLAccount> GetAllAccounts();
        void AddLoLAccount(LoLAccount accountToAdd);
        LoLAccount GetLoLAccount(int id);
        void UpdateName(LoLAccount accountToUpdate);
        void DeleteAccount(LoLAccount accountToRemove);

    }
}
