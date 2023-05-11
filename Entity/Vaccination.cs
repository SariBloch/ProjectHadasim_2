using System;
using System.Collections.Generic;

namespace DAL.Models;

public class VaccinationDTO
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? Type { get; set; }

    public int? UserId { get; set; }

}
