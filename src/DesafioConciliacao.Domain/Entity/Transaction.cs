using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioConciliacao.Domain.Entity
{
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }
        public string IdFile { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount  { get; set; }
        public string Name { get; set; }
    }
}
