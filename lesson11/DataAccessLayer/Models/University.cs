using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models;

public partial class University
{
    [JsonIgnore]
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string? UniversityName { get; set; }
    [JsonIgnore]

    public virtual Country? Country { get; set; }
}
