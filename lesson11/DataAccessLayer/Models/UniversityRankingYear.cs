using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Models;

public partial class UniversityRankingYear
{
    [JsonIgnore]
    public int? UniversityId { get; set; }

    [JsonIgnore]
    public int? RankingCriteriaId { get; set; }

    public int? Year { get; set; }

    public int? Score { get; set; }

    public virtual RankingCriterion? RankingCriteria { get; set; }

    public virtual University? University { get; set; }
}
