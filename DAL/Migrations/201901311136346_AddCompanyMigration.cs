namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "phone_nbr", c => c.String(maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "phone_nbr", c => c.String());
        }
    }
}
