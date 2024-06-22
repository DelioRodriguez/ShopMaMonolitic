using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class StatsScores : BaseEntity
{
    internal string? statsScoresID;

    public string? studentId { get; set; }
    public object? StudentId { get; internal set; }
    public int score { get; set; }
    public object StatsScoresId { get; internal set; }
}