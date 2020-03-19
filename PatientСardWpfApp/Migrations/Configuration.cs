﻿namespace PatientСardWpfApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientСardWpfApp.Models.AppDBContent>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PatientСardWpfApp.Models.AppDBContent";
        }

        protected override void Seed(PatientСardWpfApp.Models.AppDBContent context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
