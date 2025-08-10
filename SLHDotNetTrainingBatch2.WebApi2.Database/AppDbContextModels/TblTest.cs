using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.WebApi2.Database.AppDbContextModels;

public partial class TblTest
{
    public int TestId { get; set; }

    public int TestCode { get; set; }

    public string TestName { get; set; } = null!;
}
