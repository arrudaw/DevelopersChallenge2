using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DesafioConciliacao.MVC.Models
{
    public class TransactionViewModel
    {
        public int IdTransaction { get; set; }
        public string IdFile { get; set; }
        [XmlElement("TRNTYPE")]
        public string Type { get; set; }
        [XmlElement("DTPOSTED")]
        public string Date { get; set; }
        [XmlElement("TRNAMT")]
        public string Amount { get; set; }
        [XmlElement("MEMO")]
        public string Name { get; set; }

        //public int IdTransaction { get; set; }
        //public string IdFile { get; set; }
        //public string Type { get; set; }
        //public DateTime Date { get; set; }
        //public decimal Amount { get; set; }
        //public string Name { get; set; }


        //public string IdArquivo { get; set; }
        //[XmlElement("TRNTYPE")]
        //public string Tipo { get; set; }
        //[XmlElement("DTPOSTED")]
        //public string Data { get; set; }
        //[XmlElement("TRNAMT")]
        //public string Valor { get; set; }
        //[XmlElement("MEMO")]
        //public string Nome { get; set; }
    }
}