namespace DVDRenatal.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDRenatal.Repository.DVDRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DVDRenatal.Repository.DVDRentalContext context)
        {
        }
    }
}
