namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 450),
                        PublicationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .Index(t => t.BookName, unique: true)
                .Index(t => t.PublicationId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.BranchId)
                .Index(t => t.BranchName, unique: true);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationId = c.Int(nullable: false, identity: true),
                        PublicationName = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.PublicationId)
                .Index(t => t.PublicationName, unique: true);
            
            CreateTable(
                "dbo.IssuedBooks",
                c => new
                    {
                        IssuedBookId = c.Int(nullable: false, identity: true),
                        BookId = c.String(),
                        IsIssued = c.Boolean(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IssuedBookId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Semester = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Librarians",
                c => new
                    {
                        librarianUserName = c.String(nullable: false, maxLength: 128),
                        librarianName = c.String(),
                        librarianPassword = c.String(),
                    })
                .PrimaryKey(t => t.librarianUserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuedBooks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Books", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Books", "BranchId", "dbo.Branches");
            DropIndex("dbo.IssuedBooks", new[] { "StudentId" });
            DropIndex("dbo.Publications", new[] { "PublicationName" });
            DropIndex("dbo.Branches", new[] { "BranchName" });
            DropIndex("dbo.Books", new[] { "BranchId" });
            DropIndex("dbo.Books", new[] { "PublicationId" });
            DropIndex("dbo.Books", new[] { "BookName" });
            DropTable("dbo.Librarians");
            DropTable("dbo.Students");
            DropTable("dbo.IssuedBooks");
            DropTable("dbo.Publications");
            DropTable("dbo.Branches");
            DropTable("dbo.Books");
        }
    }
}
