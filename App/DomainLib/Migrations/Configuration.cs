namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DomainLib.Context.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DomainLib.Context.EfContext context)
        {
            var garten = new Kindergarden {Address = "Panomarenk Street", Number = 56};
            context.Kindergardens.Add(garten);
            context.Children.Add(new Child
            {
                Age = 4,
                FirstName = "Boris",
                LastName = "Ivanov",
                MiddleName = "Semenovich",
                Kindergarden = garten
            });
            context.Children.Add(new Child
            {
                Age = 4,
                FirstName = "Alex",
                LastName = "Ivanov",
                MiddleName = "Semenovich",
                Kindergarden = garten
            });
            context.Children.Add(new Child
            {
                Age = 4,
                FirstName = "Michael",
                LastName = "Petrov",
                MiddleName = "Semenovich",
                Kindergarden = garten
            });
        }
    }
}
