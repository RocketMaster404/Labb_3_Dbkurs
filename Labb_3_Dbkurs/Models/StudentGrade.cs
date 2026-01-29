using System;
using System.Collections.Generic;

namespace Labb_3_Dbkurs.Models;

public partial class StudentGrade
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Grade { get; set; }

    public DateOnly? GradeDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
