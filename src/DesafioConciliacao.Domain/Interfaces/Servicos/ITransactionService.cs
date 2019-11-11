using DesafioConciliacao.Domain.Entity;
using System;
using System.Collections.Generic;

namespace DesafioConciliacao.Domain.Services
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByDate(DateTime inicio, DateTime fim);
        void InsertRange(IEnumerable<Transaction> transacoes);
        void DeleteAll();
    }
}
