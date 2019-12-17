namespace MyStudentApp.Migrations
{
    using MyStudentApp.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyStudentApp.DAL.MyStudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyStudentApp.DAL.MyStudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var stundets = new List<StudentModel>
            {
                new StudentModel{Name="Super Mario Bros"},
                new StudentModel{Name="Super Mario 64"},
                new StudentModel{Name="Super Mario Galaxy"}
            };
            stundets.ForEach(e => context.Students.AddOrUpdate(p => p.Name, e));
            context.SaveChanges();

        }
    }
}
