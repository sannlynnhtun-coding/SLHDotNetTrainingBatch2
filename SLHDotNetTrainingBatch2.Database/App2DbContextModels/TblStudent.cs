using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentNo { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string MobileNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? Address { get; set; }

    public string FatherName { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
