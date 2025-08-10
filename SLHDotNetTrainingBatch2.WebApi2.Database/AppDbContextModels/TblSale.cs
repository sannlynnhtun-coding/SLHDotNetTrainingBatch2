using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.WebApi2.Database.AppDbContextModels;

public partial class TblSale
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public bool DeleteFlag { get; set; }
}
