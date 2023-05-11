using System;
using System.Collections.Generic;

namespace DAL.Models;

public class UserDTO
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BornDate { get; set; }

    public string Tell { get; set; } = null!;

    public string? Phone { get; set; }

    public string CityName { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int NumberHouse { get; set; }

    public  List<SickDTO>? Sicks { get; set; }

    public  List<VaccinationDTO>? Vaccinations { get; set; }
}
