using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models;

public partial class RankingSystem
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? SystemName { get; set; }

    [JsonIgnore]
    public virtual ICollection<RankingCriterion> RankingCriteria { get; set; } = new List<RankingCriterion>();
}
