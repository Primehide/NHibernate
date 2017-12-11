using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Domain;

namespace NHibernate.DAL
{
    public class Repository : IRepository
    {

        public void AddLoLAccount(LoLAccount accountToAdd)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(accountToAdd);
                transaction.Commit();
            }
        }

        public void DeleteAccount(LoLAccount accountToRemove)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(accountToRemove);
                transaction.Commit();
            }
        }

        public LoLAccount GetLoLAccount(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<LoLAccount>(id);
        }

        public void UpdateName(LoLAccount accountToUpdate)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(accountToUpdate);
                transaction.Commit();
            }
        }

        public IEnumerable<LoLAccount> GetAllAccounts()
        {
            IEnumerable<LoLAccount> accounts;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                accounts = session.QueryOver<LoLAccount>().List();
            }

            return accounts;
        }
    }
}
