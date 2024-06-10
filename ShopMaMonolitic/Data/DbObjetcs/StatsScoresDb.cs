using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs
{
    public class StatsScoresDb :IStatsScoresDb
    {
        private readonly ShopContext context;

        public StatsScoresDb(ShopContext context)
        {
            this.context = context;
        }

        public void DeleteStatsScores(int id)
        {
            throw new NotImplementedException();
        }

        public StatsScoresModel GetStatsScores(int statsScoresId)
        {
            var statsScores = this.context.StatsScores.Find(statsScoresId);
            ArgumentNullException.ThrowIfNull(statsScores, "StatsScores not found");

            StatsScoresModel statsScoresModel = new StatsScoresModel()
            {
                StatsScoresId = statsScores.StatsScoresId,
                StudentId = statsScores.StudentId
            };

            return statsScoresModel;
        }

        public List<StatsScoresModel> GetStatsScores()
        {
            return this.context.StatsScores.Select(cd => new StatsScoresModel()
            {
                StatsScoresId = cd.StatsScoresId,
                StudentId = cd.StudentId
            }).ToList();
        }

        public StatsScores GetStatsScoresById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStatsScores(StatsScoresRemoveModel statsScoresRemoveModel)
        {
            var statsScoresToRemove = this.context.StatsScores.Find(statsScoresRemoveModel.StatscoresID);
            if (statsScoresToRemove is null)
            {
                throw new StatsScoresException("StatsScores not found");
            }

            this.context.StatsScores.Remove(statsScoresToRemove);
            this.context.SaveChanges();

        }

        public void SaveStatsScores(StatsScoresAddModel statsScoresAdd)
        {
            StatsScores statsScores = new StatsScores()
            {
                StudentId = statsScoresAdd.StudentId!,
            };

            this.context.StatsScores.Add(statsScores);
            this.context.SaveChanges();
        }

        public void SaveStatsScores(StatsScores statsScores)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatsScores(StatsScoresUpdateModel statsScoresUpdate)
        {
            var statsScoresToUpdate = this.context.StatsScores.Find(statsScoresUpdate.testId);

            if (statsScoresToUpdate is null)
            {
                throw new StatsScoresException("This not found");

            }

            statsScoresToUpdate.StudentId = statsScoresUpdate.StudentId!;
            statsScoresToUpdate.StatsScoresId = statsScoresUpdate.Score;  //Ojo  
            this.context.StatsScores.Update(statsScoresToUpdate);
            this.context.SaveChanges();
        }

        public void UpdateStatsScores(StatsScores statsScores)
        {
            throw new NotImplementedException();
        }

        List<StatsScores> IStatsScoresDb.GetStatsScores()
        {
            throw new NotImplementedException();
        }
    }
}