using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcSampleApp.Core.Entities;

namespace MvcSampleApp.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MvcSampleAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcSampleAppContext context)
        {
            SeedCompanies(context);
            SeedEmployees(context);
        }

        private static void SeedCompanies(MvcSampleAppContext context)
        {
            var companies = new List<Company>()
            {
                new Company(){ Id= new Guid("2FD9D773-8D4B-4F83-8C97-6CAA99E436AC"), CompanyName = "Google", CreatedDateTime = DateTime.Now },
                new Company(){ Id= new Guid("535364DD-D2B4-4613-BFD1-01B52BDB6DFA"), CompanyName = "Apple", CreatedDateTime = DateTime.Now },
                new Company(){ Id= new Guid("0A19C1A9-F480-4C11-B577-5EC63A1B364C"), CompanyName = "Microsoft", CreatedDateTime = DateTime.Now },
                new Company(){ Id= new Guid("A9D990A4-86C6-4ED2-945F-F9C7D91E399A"), CompanyName = "IBM", CreatedDateTime = DateTime.Now },
                new Company(){ Id= new Guid("56501752-E5BA-48DE-99E4-76D06E897CF1"), CompanyName = "NNIT", CreatedDateTime = DateTime.Now }
            };
            context.Companies.AddRange(companies);
        }
        private static void SeedEmployees(MvcSampleAppContext context)
        {
            var employees = new List<Employee>()
            {
                new Employee(){ CompanyId = new Guid("2FD9D773-8D4B-4F83-8C97-6CAA99E436AC"), Id = Guid.NewGuid(), FirstName = "Waylon", MiddleName = "Moon", LastName = "Dalton", CreatedDateTime = DateTime.Now },
                new Employee(){ CompanyId = new Guid("2FD9D773-8D4B-4F83-8C97-6CAA99E436AC"), Id = Guid.NewGuid(), FirstName = "Marcus", MiddleName = "Terrell", LastName = "Cruz", CreatedDateTime = DateTime.Now },

                new Employee(){ CompanyId = new Guid("535364DD-D2B4-4613-BFD1-01B52BDB6DFA"), Id = Guid.NewGuid(), FirstName = "Eddie", MiddleName = "Campbell", LastName = "Randolph", CreatedDateTime = DateTime.Now },
                new Employee(){ CompanyId = new Guid("535364DD-D2B4-4613-BFD1-01B52BDB6DFA"), Id = Guid.NewGuid(), FirstName = "Hadassah", MiddleName = "Mcconnell", LastName = "Sheppard", CreatedDateTime = DateTime.Now },

                new Employee(){ CompanyId = new Guid("0A19C1A9-F480-4C11-B577-5EC63A1B364C"), Id = Guid.NewGuid(), FirstName = "Justine", MiddleName = "Delgado", LastName = "Shelton", CreatedDateTime = DateTime.Now },
                new Employee(){ CompanyId = new Guid("0A19C1A9-F480-4C11-B577-5EC63A1B364C"), Id = Guid.NewGuid(), FirstName = "Thalia", MiddleName = "Lucero", LastName = "Little", CreatedDateTime = DateTime.Now },

                new Employee(){ CompanyId = new Guid("A9D990A4-86C6-4ED2-945F-F9C7D91E399A"), Id = Guid.NewGuid(), FirstName = "Angela", MiddleName = "Santos", LastName = "Henderson", CreatedDateTime = DateTime.Now },
                new Employee(){ CompanyId = new Guid("A9D990A4-86C6-4ED2-945F-F9C7D91E399A"), Id = Guid.NewGuid(), FirstName = "Joanna", MiddleName = "Shepard", LastName = "Cobb", CreatedDateTime = DateTime.Now },

                new Employee(){ CompanyId = new Guid("56501752-E5BA-48DE-99E4-76D06E897CF1"), Id = Guid.NewGuid(), FirstName = "Abdullah", MiddleName = "Aspen", LastName = "Lang", CreatedDateTime = DateTime.Now },
                new Employee(){ CompanyId = new Guid("56501752-E5BA-48DE-99E4-76D06E897CF1"), Id = Guid.NewGuid(), FirstName = "Mathias", MiddleName = "Wolf", LastName = "Walker", CreatedDateTime = DateTime.Now }
            };
            context.Employees.AddRange(employees);
        }
    }
}
