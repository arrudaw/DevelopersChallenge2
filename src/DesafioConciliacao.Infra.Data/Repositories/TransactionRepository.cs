using System;
using System.Collections.Generic;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Domain.Interfaces.Repositories;
using System.Linq;

namespace DesafioConciliacao.Infra.Data.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public void DeleteAll()
        {
            var transactions = Db.Transaction.ToList();

            this.Db.Transaction.RemoveRange(transactions);
            this.Db.SaveChanges();
            //this.Db.Database.ExecuteSqlCommand("delete from Transacao");

        }

        public IEnumerable<Transaction> GetTransactionsByDate(DateTime inicio, DateTime fim)
        {
            return Db.Transaction.Where(t => t.Date >= inicio && t.Date <= fim).OrderBy(o => o.Date).ToList();
        }

        public void InsertRange(IEnumerable<Transaction> transacoes)
        {
            this.Db.Transaction.AddRange(transacoes);
        }
    }
}