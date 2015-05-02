using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWorkshop.Domain;

namespace EFWorkshop.Map
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //this.ToTable("WorkshopStudent");
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(100);

            this.HasOptional(o => o.Address).WithRequired(r => r.Student);

            this.HasRequired(r => r.StudentClass).WithMany(m => m.Students).HasForeignKey(f => f.ClassId).WillCascadeOnDelete(false);

            this.HasMany(m => m.Courses).WithMany(s => s.Students).Map(
                cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("StudentCourseMap");
                }
                );
        }
    }
}
