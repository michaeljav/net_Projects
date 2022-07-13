using System.Security.AccessControl;
using System.Collections.Generic;
namespace ef.Entities
 {

  public class Author {
    public int ID {get; set;}
    public string Name {get; set;}

    /*un autor tiene varios cursos*/
    public List<Course> Courses {get; set;} = new();
  }
}