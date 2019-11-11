using DesafioConciliacao.Domain.Entity;
using System;
using System.Collections.Generic;

namespace DesafioConciliacao.Application.Interface
{
    public interface ITransactionAppService : IAppServiceBase<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByDate(DateTime inicio, DateTime fim);
        void InsertRange(IEnumerable<Transaction> transacoes);
        void DeleteAll();
    }
}
