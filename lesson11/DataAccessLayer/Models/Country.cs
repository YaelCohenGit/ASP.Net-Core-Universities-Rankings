using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models;

public partial class Country
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? CountryName { get; set; }
    [JsonIgnore]
    public virtual ICollection<University> Universities { get; set; } = new List<University>();
}
