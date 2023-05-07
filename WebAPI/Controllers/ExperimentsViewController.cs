using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{   //Контроллер для отображения статистики проведённых экспериментов.
    [Controller]
    [Route("ExperimentsObserver")]
    public class ExperimentsViewController : Controller
    {
        #region PrivateField
        private readonly IExperimentsRepository _experimentsRepository;
        #endregion

        #region Constructor
        public ExperimentsViewController(IExperimentsRepository experimentsRepository)
        {
            _experimentsRepository = experimentsRepository;
        }
        #endregion

        #region Method
        public async Task<IActionResult> GetExperimentsAsync()
        {   //Шаг 1 - Асинхронно получаем список всех проведённых экспериментов в нашей базе данных.
            //Шаг 2 - Группируем объекты основываясь на категории результатов => выходном значении цвета,
            //группируем и отправляем на страницу представления статистики.
            var experiments = await _experimentsRepository.GetExperiments();
            var experimentsByGroup = experiments.GroupBy(e => e.ColorGroup).ToList();
            return View(experimentsByGroup);
        }
        #endregion
    }
}
