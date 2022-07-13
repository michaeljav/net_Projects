using System;
using System.Collections.Generic;

namespace ef
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new CoursesDbContext();
            //Asegurarse que la base de datos este creada sino esta la crea por primera vez
            dbContext.Database.EnsureCreated();


            //Insert author
            dbContext.Author.Add(new Entities.Author()
            {
                Name = "Michael Javier Mota",
                Courses = new List<Entities.Course>(new[] {
                    new Entities.Course() {Name = "Net 5 "},
                    new Entities.Course() {Name = "Net 5  essencial"},
                })
            });
            dbContext.SaveChanges();

            Console.WriteLine("Listo");
        }
    }
}
