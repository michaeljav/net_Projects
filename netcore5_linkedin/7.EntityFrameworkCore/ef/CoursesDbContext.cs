using ef.Entities;
using Microsoft.EntityFrameworkCore;

namespace ef
 {

  public class CoursesDbContext:DbContext {
    public DbSet<Author> Author {get; set;}
    public DbSet<Course> Courses {get; set;}
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
          //  optionsBuilder.UseSqlServer(@"data source=.\sqlexpress;initial catalog=Courses;Integrated Security=yes");
            //optionsBuilder.UseSqlServer(@"data source=172.30.3.43;initial catalog=Courses;Integrated Security=yes");
            //optionsBuilder.UseSqlServer(@"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=AppUpdate;Data Source=172.30.3.43");
            //optionsBuilder.UseSqlServer(@"Provider=SQLSERVER;Integrated Security=SSPI;Persist Security Info=False;Data Source=172.30.3.43");
            //worked
            //optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Data Source=172.30.3.43");

            optionsBuilder.UseSqlServer(@"Integrated Security=yes; initial catalog=Courses; Data Source=172.30.3.43");
            //
            //optionsBuilder.UseSqlServer(@"data source=172.30.3.43;initial catalog=Courses;Integrated Security=yes");

        }

    }
}