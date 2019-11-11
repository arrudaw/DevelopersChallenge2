using AutoMapper;
using DesafioConciliacao.Application.Interface;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Domain.Interfaces.Repositories;
using DesafioConciliacao.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioConciliacao.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUploadFileAppService _uploadFileApp;
        private IParseOFXContent _parseOFXContent;
        private ITransactionRepository _extratoRepository;

        public ActionResult Index()
        {
            return View();
        }

        public HomeController(IUploadFileAppService uploadFile,
            IParseOFXContent parseOFXContent,
            ITransactionRepository extratoRepository
           //IImportOfxFile importOfxFile,
           //IGetTransacoesUseCase getTransacoesUseCase,
           //IExcluirTransacoesUseCase excluirTransacoesUseCase
           )
        {
            this._uploadFileApp = uploadFile;
            this._parseOFXContent = parseOFXContent;
            this._extratoRepository = extratoRepository;
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {

                var ofxFile = _uploadFileApp.Upload(files, Server.MapPath("~/OfxFiles/"));

                var transacoes = ImportWithMerge(ofxFile);

                return View("ImportedData", transacoes);
            }

            return View("ImportedData", new List<TransactionViewModel>());

        }

        [HttpPost]
        public ActionResult Excluir()
        {
            this._extratoRepository.DeleteAll();

            return View("Index");

        }

        public ActionResult ImportedOfx()
        {
            return View();
        }

        public ActionResult Extrato()
        {

            var extrato = _extratoRepository.GetAll();
            return View("ImportedData", extrato);
        }

        /// <summary>
        /// Import OFX Files with merge
        /// </summary>
        /// <param name="OfxFiles"></param>
        /// <returns></returns>
        public List<Transaction> ImportWithMerge(List<string> OfxFiles)
        {
            var transacoes = new List<Transaction>();

            if (OfxFiles.Count > 0)
            {
                foreach (var item in OfxFiles)
                {
                    string[] lines = System.IO.File.ReadAllLines(item);

                    ArquivoModel ofx = this._parseOFXContent.ToObject<ArquivoModel>(lines);

                    Guid identificacaoArquivo = Guid.NewGuid();

                    foreach (var current in ofx.STMTTRN)
                    {

                        var currentMapped = Mapper.Map<TransactionViewModel, Transaction>(current);

                        var qtdLocal = transacoes.Where(x => x.Date == currentMapped.Date && x.Name == currentMapped.Name && x.Type == currentMapped.Type && x.Amount == currentMapped.Amount && x.IdFile != identificacaoArquivo.ToString()).Count();
                        var qtd = _extratoRepository.GetAll().Where(x => x.Date == currentMapped.Date && x.Name == currentMapped.Name && x.Type == currentMapped.Type && x.Amount == currentMapped.Amount && x.IdFile != identificacaoArquivo.ToString()).Count();


                        // Save only data that is not repeated in files
                        if (qtd == 0 && qtdLocal == 0)
                        {
                            currentMapped.IdFile = identificacaoArquivo.ToString();
                            transacoes.Add(currentMapped);

                            this._extratoRepository.Add(currentMapped);

                        }
                    }
                }
            }


            this._extratoRepository.Save();

            return transacoes;
        }
    }
}