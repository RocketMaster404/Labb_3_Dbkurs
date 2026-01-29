using System;
using System.Collections.Generic;

namespace Labb_3_Dbkurs.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalNr { get; set; } = null!;

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
}
