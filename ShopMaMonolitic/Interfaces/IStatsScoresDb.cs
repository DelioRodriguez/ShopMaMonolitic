using ShopMaMonolitic.Data.Entities;

namespace ShopMaMonolitic.Data.Interfaces;

public interface IStatsScoresDb
{
    List<StatsScores> GetStatsScores();
    StatsScores GetStatsScoresById(int id);
    void SaveStatsScores(StatsScores statsScores);
    void UpdateStatsScores(StatsScores statsScores);
    void DeleteStatsScores(int id);

}