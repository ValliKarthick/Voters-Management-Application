namespace Voters_Management_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voters Information",
                c => new
                    {
                        EPICNumber = c.String(name: "EPIC Number", nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(name: "Date Of Birth", nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(maxLength: 1),
                        VotingLocation = c.String(name: "Voting Location"),
                    })
                .PrimaryKey(t => t.EPICNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voters Information");
        }
    }
}
