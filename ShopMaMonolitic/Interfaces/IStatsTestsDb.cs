using ShopMaMonolitic.Data.Entities;
using System.Collections.Generic;

namespace ShopMaMonolitic.Data.Interfaces;

public interface IStatsTestsDb
    {
        List<IStatsTestsDb> GetStatsTests();
        StatsTests GetStatsTestsById(int id);
        void SaveStatsTests(StatsTests statsTests);
        void UpdateStatsTests(StatsTests statsTests);
        void DeleteStatsTests(int id);
    }