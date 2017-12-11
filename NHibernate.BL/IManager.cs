using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Domain;

namespace NHibernate.BL
{
    public interface IManager
    {
        void AddLoLAccount(LoLAccount AccountToAdd);
        void ChangeName(LoLAccount AccountToUpdate);
        void DeleteAccount(LoLAccount AccountToDelete);
        LoLAccount ReadAccount(int id);
        IEnumerable<LoLAccount> ReadAllAccounts();
    }
}
