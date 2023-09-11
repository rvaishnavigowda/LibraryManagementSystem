namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IssueBookUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssuedBooks", "IssueDate", c => c.String());
            AlterColumn("dbo.IssuedBooks", "ReturnDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssuedBooks", "ReturnDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IssuedBooks", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
