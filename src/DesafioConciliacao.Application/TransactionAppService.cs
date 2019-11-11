using DesafioConciliacao.Application.Interface;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioConciliacao.Application
{
   
    public class TransactionAppService : AppServiceBase<Transaction>, ITransactionAppService
    {

        private readonly ITransactionService _transactionService;

        public TransactionAppService(ITransactionService transactionService)
            :base(transactionService)
        {
            _transactionService = transactionService;
        }

        
        IEnumerable<Transaction> ITransactionAppService.GetTransactionsByDate(DateTime inicio, DateTime fim)
        {
            return _transactionService.GetTransactionsByDate(inicio, fim);
        }

        void ITransactionAppService.InsertRange(IEnumerable<Transaction> transacoes)
        {
            _transactionService.InsertRange(transacoes);
        }

        void ITransactionAppService.DeleteAll()
        {
            _transactionService.DeleteAll();
        }
    }
}