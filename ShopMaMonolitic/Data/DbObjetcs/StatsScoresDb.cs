using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Model.StatsScores;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class StatsScoresDb : IStatsScoresDb
{
    private readonly ShopContext context;

    public StatsScoresDb(ShopContext context)
    {
        this.context = context;
    }

    public ShopContext Context => context;

    public StatsScoresModel MapToModel(StatsScores statsScores)
    {
        return new StatsScoresModel
        {
            StatsScoresId = statsScores.StatsScoresId,
            StudentId = statsScores.StudentId
        };
    }

    public StatsScores GetStatsScoresById(string statsScoresId)
    {
        var statsScores = this.context.StatsScores.Find(statsScoresId);
        if (statsScores == null)
        {
            throw new StatsScoresException("StatsScores not found");
        }
        return statsScores;
    }

    public StatsScores GetStatsScoresByStudentId(string studentId)
    {
        var statsScores = this.context.StatsScores.Find(studentId);
        if (statsScores == null)
        {
            throw new StatsScoresException("StatsScores not found");
        }
        return statsScores;
    }


    public void AddStatsScores(StatsScores statsScores)
    {
        this.context.StatsScores.Add(statsScores);
        this.context.SaveChanges();
    }

    public List<StatsScores> GetStatsScores()
    {
        throw new NotImplementedException();
    }

    public List<StatsScores> GetStatsScoresById()
    {
        throw new NotImplementedException();
    }

    public StatsScores GetStatsScoresById(int id)
    {
        throw new NotImplementedException();
    }

    public void SaveStatsScores(StatsScores statsScores)
    {
        throw new NotImplementedException();
    }

    public void UpdateStatsScores(StatsScores statsScores)
    {
        throw new NotImplementedException();
    }

    public void DeleteStatsScores(int id)
    {
        throw new NotImplementedException();
    }
}