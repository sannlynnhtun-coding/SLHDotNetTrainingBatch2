using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblSale
{
    public DateTime SaleDate { get; set; }

    public int No { get; set; }

    public decimal Amount { get; set; }
}
