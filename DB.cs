using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyDBNames.Scheme
{
    //определение модели данных
    public class Solving_the_backpack_problem
    {
        public int Id { get; set; } 
        public string Task_type { get; set; }
        public int Backpack_weight { get; set; }
        public int Number_of_items { get; set; }
        public int Answer { get; set; }
        public string Items { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy hh:mm:ss}", ApplyFormatInEditMode =true)]
        public DateTime Date_time { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        //DbSet представляет собой список сущностей, хранящихся в базе данных. 
        public DbSet<Solving_the_backpack_problem> Solving_the_backpack_problem { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           //создание БД, если она отсутствует
            Database.EnsureCreated();
        }

    }
}