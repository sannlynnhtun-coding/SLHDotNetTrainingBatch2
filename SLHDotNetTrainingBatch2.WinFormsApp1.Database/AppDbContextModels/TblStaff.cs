using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string StaffCode { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public bool IsDelete { get; set; }
}
