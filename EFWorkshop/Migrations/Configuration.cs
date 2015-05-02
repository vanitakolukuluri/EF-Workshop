using EFWorkshop.Domain;

namespace EFWorkshop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFWorkshop.WorkshopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFWorkshop.WorkshopContext context)
        {
            var scienceClass = new StudentClass
            {
                Id = 1,
                Name = "Science"
            };
            context.StudentClasses.AddOrUpdate(scienceClass);
            context.Students.AddOrUpdate(new Student
                {
                    Id = 1,
                    Name = "Vanita",
                    Address = new Address {State = "PA", City = "Pittsburgh"},
                    ClassId = scienceClass.Id
                }
            );
        }
    }
}
