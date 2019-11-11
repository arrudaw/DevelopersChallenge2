using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DesafioConciliacao.MVC.Models
{
    public class TransactionModel
    {
        public string IdArquivo { get; set; }
        [XmlElement("TRNTYPE")]
        public string Tipo { get; set; }
        [XmlElement("DTPOSTED")]
        public string Data { get; set; }
        [XmlElement("TRNAMT")]
        public string Valor { get; set; }
        [XmlElement("MEMO")]
        public string Nome { get; set; }
    }
}