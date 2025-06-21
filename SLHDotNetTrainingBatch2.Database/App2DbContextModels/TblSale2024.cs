using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblSale2024
{
    public int Id { get; set; }

    public DateTime SaleDate { get; set; }

    public int No { get; set; }

    public decimal? Amount { get; set; }
}
