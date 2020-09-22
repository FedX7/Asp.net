using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Many1.Models
{
    public class Initializer : DropCreateDatabaseAlways<TeamContext>
    {
        protected override void Seed(TeamContext context)
        {
            Worker s1 = new Worker { Id = 1, Name = "Егор", Surname = "Белов", Patronymic = "Сергеевич", Email="Egor@mail.ru" };
            Worker s2 = new Worker { Id = 2, Name = "Мария", Surname = "Жижина", Patronymic = "Владимировна", Email = "Maria@mail.ru" };
            Worker s3 = new Worker { Id = 3, Name = "Олег", Surname = "Седов", Patronymic = "Игоревич", Email = "Oleg@mail.ru" };
            Worker s4 = new Worker { Id = 4, Name = "Ольга", Surname = "Захаренко", Patronymic = "Павловна", Email = "Olga@mail.ru" };

            context.Workers.Add(s1);
            context.Workers.Add(s2);
            context.Workers.Add(s3);
            context.Workers.Add(s4);

            Project c1 = new Project
            {
                Id = 1,
                Name = "IPhone100X",
                Priority = 1,
                Customer = "Apple",
                Performer = "Sibers",
                Leader = "Егор",
                Workers = new List<Worker>() { s1, s2, s3 },
                DateStart = new DateTime(2021, 1, 1),
                DateEnd = new DateTime(2021, 2, 2)
            };
            Project c2 = new Project
            {
                Id = 2,
                Name = "Galaxy 87 Pro",
                Priority = 2,
                Customer = "Samsung",
                Performer = "Sibsutis",
                Leader = "Мария",
                Workers = new List<Worker>() { s2, s4 },
                DateStart = new DateTime(2021, 5, 5),
                DateEnd = new DateTime(2021, 6, 6)
            };
            Project c3 = new Project
            {
                Id = 3,
                Name = "Windows 46",
                Priority = 3,
                Customer = "Microsoft",
                Performer = "IP612",
                Leader = "Олег",
                Workers = new List<Worker>() { s3, s4, s1 },
                DateStart = new DateTime(2021, 3, 3),
                DateEnd = new DateTime(2021, 4, 4)
            };
            

            context.Projects.Add(c1);
            context.Projects.Add(c2);
            context.Projects.Add(c3);
            

            base.Seed(context);
        }
    }
}