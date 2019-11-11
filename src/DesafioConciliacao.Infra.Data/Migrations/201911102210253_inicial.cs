namespace DesafioConciliacao.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        IdTransaction = c.Int(nullable: false, identity: true),
                        IdFile = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Type = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 5, scale: 2),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IdTransaction);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transaction");
        }
    }
}
