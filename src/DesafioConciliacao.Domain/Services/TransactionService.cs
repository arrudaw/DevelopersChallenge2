using System;
using System.Collections.Generic;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Domain.Interfaces.Repositories;

namespace DesafioConciliacao.Domain.Services
{
    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
            : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void DeleteAll()
        {
            _transactionRepository.DeleteAll();
        }

        public IEnumerable<Transaction> GetTransactionsByDate(DateTime inicio, DateTime fim)
        {
            return _transactionRepository.GetTransactionsByDate(inicio, fim);
        }

        public void InsertRange(IEnumerable<Transaction> transacoes)
        {
            _transactionRepository.InsertRange(transacoes);
        }
    }
}
