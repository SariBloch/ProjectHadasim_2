using System;
using System.Collections.Generic;

namespace DAL.Models;

public class SickDTO
{
    public int Id { get; set; }

    public DateTime DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? UserId { get; set; }

}
