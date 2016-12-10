namespace _4th_Year_BMS_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _4th_Year_BMS_Project.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;



    internal sealed class Configuration : DbMigrationsConfiguration<_4th_Year_BMS_Project.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_4th_Year_BMS_Project.Models.ApplicationDbContext";
        }

        bool AddUserAndRole(_4th_Year_BMS_Project.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "first.hadron@gmail.com",
            };
            ir = um.Create(user, "Tom12345#");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(_4th_Year_BMS_Project.Models.ApplicationDbContext context)
        {
            //AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Name,
                   new Contact
                   {
                       Name = "Debra Garcia",
                       Address = "1234 Main St",
                       City = "Redmond",
                       State = "WA",
                       Zip = "10999",
                       Email = "debra@example.com",
                       UserName = "tom1",
                       PasswordIn = "Tom1+",
                       electrical_Circuit_1 = 1,
                       electrical_Circuit_2 = 1,
                       electrical_Circuit_3 = 1,
                       electrical_Circuit_4 = 1,
                       heating_Circuit_1 = 1,
                       heating_Circuit_2 = 1,
                       heating_Circuit_3 = 1,
                       heating_Circuit_4 = 1,
                       door_access = 1,
                   },
                    new Contact
                    {
                        Name = "Thorsten Weinrich",
                        Address = "5678 1st Ave W",
                        City = "Redmond",
                        State = "WA",
                        Zip = "10999",
                        Email = "thorsten@example.com",
                        UserName = "tom2",
                        PasswordIn = "Tom2+",
                        electrical_Circuit_1 = 1,
                        electrical_Circuit_2 = 1,
                        electrical_Circuit_3 = 1,
                        electrical_Circuit_4 = 1,
                        heating_Circuit_1 = 1,
                        heating_Circuit_2 = 1,
                        heating_Circuit_3 = 1,
                        heating_Circuit_4 = 1,
                        door_access = 1,
                    },
                    new Contact
                    {
                        Name = "Yuhong Li",
                        Address = "9012 State st",
                        City = "Redmond",
                        State = "WA",
                        Zip = "10999",
                        Email = "yuhong@example.com",
                        UserName = "tom3",
                        PasswordIn = "Tom3+",
                        electrical_Circuit_1 = 1,
                        electrical_Circuit_2 = 1,
                        electrical_Circuit_3 = 1,
                        electrical_Circuit_4 = 1,
                        heating_Circuit_1 = 1,
                        heating_Circuit_2 = 1,
                        heating_Circuit_3 = 1,
                        heating_Circuit_4 = 1,
                        door_access = 1,
                    },
                    new Contact
                    {
                        Name = "Jon Orton",
                        Address = "3456 Maple St",
                        City = "Redmond",
                        State = "WA",
                        Zip = "10999",
                        Email = "jon@example.com",
                        UserName = "tom4",
                        PasswordIn = "Tom4+",
                        electrical_Circuit_1 = 1,
                        electrical_Circuit_2 = 1,
                        electrical_Circuit_3 = 1,
                        electrical_Circuit_4 = 1,
                        heating_Circuit_1 = 1,
                        heating_Circuit_2 = 1,
                        heating_Circuit_3 = 1,
                        heating_Circuit_4 = 1,
                        door_access = 1,
                    },
                    new Contact
                    {
                        Name = "Diliana Alexieva-Bosseva",
                        Address = "7890 2nd Ave E",
                        City = "Redmond",
                        State = "WA",
                        Zip = "10999",
                        Email = "diliana@example.com",
                        UserName = "tom5",
                        PasswordIn = "Tom5+",
                        electrical_Circuit_1 = 1,
                        electrical_Circuit_2 = 1,
                        electrical_Circuit_3 = 1,
                        electrical_Circuit_4 = 1,
                        heating_Circuit_1 = 1,
                        heating_Circuit_2 = 1,
                        heating_Circuit_3 = 1,
                        heating_Circuit_4 = 1,
                        door_access = 1,
                    }
                    );
        }
    }
}
