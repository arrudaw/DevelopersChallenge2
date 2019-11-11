using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DesafioConciliacao.MVC.Models
{
    [XmlRoot("BANKTRANLIST")]
    public class ArquivoModel
    {
        [XmlElement("DTSTART")]
        public string Inicio { get; set; }
        [XmlElement("DTEND")]
        public string Fim { get; set; }

        [XmlElement("STMTTRN")]
        public List<TransactionModel> STMTTRN { get; set; }

    }
}