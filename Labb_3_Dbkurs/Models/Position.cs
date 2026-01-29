using System;
using System.Collections.Generic;

namespace Labb_3_Dbkurs.Models;

public partial class Position
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public string? Position1 { get; set; }

    public virtual Employee? Employee { get; set; }
}
