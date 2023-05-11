using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Vaccination
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? Type { get; set; }

    public int? UserId { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
