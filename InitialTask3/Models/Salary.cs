using System;
using System.Collections.Generic;

namespace InitialTask3.Models;

public partial class Salary
{
    public long ActualAnnualSalary { get; set; }

    public long? LastYearOtherIncome { get; set; }

    public long? TotalIncome { get; set; }
}
