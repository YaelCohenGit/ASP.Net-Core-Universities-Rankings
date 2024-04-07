using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models;

public partial class RankingCriterion
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonIgnore]
    public int? RankingSystemId { get; set; }

    public string? CriteriaName { get; set; }

    public virtual RankingSystem? RankingSystem { get; set; }
}
