using DesafioConciliacao.Application.Interface;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioConciliacao.Application
{
    public class ImportOfxFile : IImportOfxFile
    {
        private IParseOFXContent _parseOFXContent;
        private ITransactionRepository _extratoRepository;

        public ImportOfxFile() { }

        public ImportOfxFile(IParseOFXContent parseOFXContent, ITransactionRepository extratoRepository)
        {
            this._parseOFXContent = parseOFXContent;
            this._extratoRepository = extratoRepository;
        }

        /// <summary>
        /// Import OFX Files with merge
        /// </summary>
        /// <param name="OfxFiles"></param>
        /// <returns></returns>
        //public List<Transaction> ImportWithMerge(List<string> OfxFiles)
        //{
        //    var transacoes = new List<Transaction>();

        //    if (OfxFiles.Count > 0)
        //    {
        //        foreach (var item in OfxFiles)
        //        {
        //            string[] lines = System.IO.File.ReadAllLines(item);

        //            ArquivoModel ofx = this._parseOFXContent.ToObject<ArquivoModel>(lines);               

        //            Guid identificacaoArquivo = Guid.NewGuid();

        //            foreach (var current in ofx.STMTTRN)
        //            {

        //                var currentMapped = Mapper.Map<TransactionModel, Transaction>(current);

        //                var qtdLocal = transacoes.Where(x => x.Date == currentMapped.Date && x.Name == currentMapped.Name && x.Type == currentMapped.Type && x.Amount == currentMapped.Amount && x.IdFile != identificacaoArquivo.ToString()).Count();
        //                var qtd = _extratoRepository.GetAll().Where(x => x.Date == currentMapped.Date && x.Name == currentMapped.Name && x.Type == currentMapped.Type && x.Amount == currentMapped.Amount && x.IdFile != identificacaoArquivo.ToString()).Count();


        //                // Save only data that is not repeated in files
        //                if (qtd == 0 && qtdLocal == 0)
        //                {
        //                    currentMapped.IdFile = identificacaoArquivo.ToString();
        //                    transacoes.Add(currentMapped);

        //                    this._extratoRepository.Add(currentMapped);
                            
        //                }
        //            }
        //        }
        //    }


        //    this._extratoRepository.Save();

        //    return transacoes;
        //}

    }
}
