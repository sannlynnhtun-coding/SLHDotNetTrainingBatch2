using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.Project1.Database.AppDbContextModels;

public partial class TblSale
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? SaleDate { get; set; }

    public bool DeleteFlag { get; set; }
}
