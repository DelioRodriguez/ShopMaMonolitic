using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Model.StatsTests;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class StatsTestsDb : IStatsTests
{
    private readonly ShopContext context;

    public StatsTestsDb(ShopContext context)
    {
        this.context = context;
    }

    public ShopContext Context => context;

    public StatsTestsModel MapToModel(StatsTests statsTests)
    {
        return new StatsTestsModel
        {
            StatsTestsId = statsTests.StatsTestsId
        };
    }

    public StatsTests GetStatsTestsById(string statsTestsId)
    {
        var statsTests = this.context.StatsTests.Find(statsTestsId);
        if (statsTests == null)
        {
            throw new StatsTestException("StatsTests not found");
        }
        return statsTests;
    }

    public void AddStatsTests(StatsTests statsTests)
    {
        this.context.StatsTests.Add(statsTests);
        this.context.SaveChanges();
    }

    public List<StatsTests> GetStatsTests()
    {
        throw new NotImplementedException();
    }

    public StatsTests GetStatsTestsById(int id)
    {
        throw new NotImplementedException();
    }

    public void SaveStatsTests(StatsTests statsTests)
    {
        throw new NotImplementedException();
    }

    public void UpdateStatsTests(StatsTests statsTests)
    {
        throw new NotImplementedException();
    }

    public void DeleteStatsTests(int id)
    {
        throw new NotImplementedException();
    }
}
