using DesafioConciliacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioConciliacao.Infra.Data.EntityConfig
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            HasKey(t => t.IdTransaction);

            Property(t => t.IdFile)
                .IsRequired();

            Property(t => t.Type)
                .IsRequired();

            Property(p => p.Date)
             .HasColumnType("datetime");

            Property(t => t.Amount)
                .HasColumnType("decimal")
               // .HasPrecision(5, 2)                
                .IsRequired();
            
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);            
        }
    }
}

