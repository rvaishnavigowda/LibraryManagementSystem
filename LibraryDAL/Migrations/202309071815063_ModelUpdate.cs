namespace LibraryDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IssuedBooks", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.IssuedBooks", new[] { "Student_StudentId" });
            RenameColumn(table: "dbo.IssuedBooks", name: "Student_StudentId", newName: "StudentId");
            AlterColumn("dbo.IssuedBooks", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.IssuedBooks", "StudentId");
            AddForeignKey("dbo.IssuedBooks", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            DropColumn("dbo.IssuedBooks", "studentKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssuedBooks", "studentKey", c => c.Int(nullable: false));
            DropForeignKey("dbo.IssuedBooks", "StudentId", "dbo.Students");
            DropIndex("dbo.IssuedBooks", new[] { "StudentId" });
            AlterColumn("dbo.IssuedBooks", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.IssuedBooks", name: "StudentId", newName: "Student_StudentId");
            CreateIndex("dbo.IssuedBooks", "Student_StudentId");
            AddForeignKey("dbo.IssuedBooks", "Student_StudentId", "dbo.Students", "StudentId");
        }
    }
}
