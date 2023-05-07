using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    //Интерфейс для взаимодействия с классом-репозиторием
    public interface IExperimentsRepository : IDisposable
    {
        #region Methods
        Task<Experiment> GetExperiment(Guid deviceToken);
        Task AddExperimentAsync(Experiment experiment);
        Task<List<Experiment>> GetExperiments();
        #endregion
    }
}
