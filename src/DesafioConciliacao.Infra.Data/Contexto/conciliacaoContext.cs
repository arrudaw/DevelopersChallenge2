using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DesafioConciliacao.Infra.Data.Contexto
{
    public class ConciliacaoContext : DbContext
    {
        public ConciliacaoContext()
            :base("Conciliacao")
        {

        }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new TransactionConfiguration());


        }
    }
}
