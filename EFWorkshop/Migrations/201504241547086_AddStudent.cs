namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentClass", t => t.ClassId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourseMap",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "ClassId", "dbo.StudentClass");
            DropForeignKey("dbo.StudentCourseMap", "CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourseMap", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Address", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentCourseMap", new[] { "CourseId" });
            DropIndex("dbo.StudentCourseMap", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Address", new[] { "StudentId" });
            DropTable("dbo.StudentCourseMap");
            DropTable("dbo.StudentClass");
            DropTable("dbo.Course");
            DropTable("dbo.Student");
            DropTable("dbo.Address");
        }
    }
}
