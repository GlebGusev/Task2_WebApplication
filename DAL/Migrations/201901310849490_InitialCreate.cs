namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        last_name = c.String(nullable: false, maxLength: 15),
                        first_name = c.String(nullable: false, maxLength: 15),
                        father_name = c.String(nullable: false, maxLength: 15),
                        birth_dt = c.DateTime(nullable: false),
                        email = c.String(maxLength: 50),
                        phone_nbr = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
        }
    }
}
