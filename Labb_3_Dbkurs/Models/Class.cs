using System;
using System.Collections.Generic;

namespace Labb_3_Dbkurs.Models;

public partial class Class
{
    public int Id { get; set; }

    public string ClassName { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
