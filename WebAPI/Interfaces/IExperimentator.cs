using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{   //Интерфейс для регистрации зависимостей в DI-контейнере.
    public interface IExperimentator
    {
        #region Method
        Task<Experiment> GetExperimentResultAsync(Guid deviceToken);
        #endregion
    }
}
