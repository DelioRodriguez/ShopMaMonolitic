using ShopMaMonolitic.Data.Core;

namespace ShopMaMonolitic.Data.Entities;

public class StatsScores : BaseEntity
{
    public string studentId { get; set; }
    public int score { get; set; }
}