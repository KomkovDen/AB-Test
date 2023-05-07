using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Interfaces;

namespace WebAPI.Models
{
    //Класс для взаимодействия между EntityFramework и базой данных.
    //Был использован шаблон паттерна "Репозиторий"
    public class ExperimentRepository : IExperimentsRepository
    {
        #region PrivateField
        private readonly ExperimentContext _dbContext;
        #endregion

        #region Methods
        public ExperimentRepository(ExperimentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Experiment> GetExperiment(Guid id)
        {
            return await _dbContext.Experiments.FindAsync(id);
        }

        public async Task AddExperimentAsync(Experiment entity)
        {
            await _dbContext.Experiments.AddAsync(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Experiment>> GetExperiments()
        {
            return await _dbContext.Experiments.ToListAsync();
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (!_disposed)
            {
                _dbContext.Dispose();
                GC.SuppressFinalize(this);
            }
            _disposed = true;
        }
        #endregion
    }
}
