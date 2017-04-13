namespace _4th_Year_BMS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        PasswordIn = c.String(),
                        electrical_Circuit_1 = c.Int(nullable: false),
                        electrical_Circuit_2 = c.Int(nullable: false),
                        electrical_Circuit_3 = c.Int(nullable: false),
                        electrical_Circuit_4 = c.Int(nullable: false),
                        heating_Circuit_1 = c.Int(nullable: false),
                        heating_Circuit_2 = c.Int(nullable: false),
                        heating_Circuit_3 = c.Int(nullable: false),
                        heating_Circuit_4 = c.Int(nullable: false),
                        door_access = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
