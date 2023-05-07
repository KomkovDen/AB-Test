using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{   
    //Контроллер принимающий GET-запрос, который возвращает результат эксперимента клиенту.
    [ApiController]
    [Route("Experiments")]
    public class ExperimentController : ControllerBase
    {
        #region PrivateField
        private IExperimentator _experimentator;
        #endregion

        #region Constructor
        public ExperimentController(IExperimentator experimentator)
        {
            _experimentator = experimentator;
        }
        #endregion

        #region EndPoint
        [HttpGet]
        public async Task<object> EndpointColor([FromQuery] Guid deviceToken)
        {
            //Шаг 1 - проверяем валидность GET-запроса и возвращаем сообщение об ошибке, в случае необходимости.
            //Шаг 2 - выполняем асинхронный запрос о наличии данного эксперимента в базе данных.
            //Шаг 3 - Сериализуем ответ в формат JSON и отправляем клиенту.
            if (deviceToken == null)
            {
                BadRequest();
            }

            Experiment response = await _experimentator.GetExperimentResultAsync(deviceToken);

            var result = JsonConvert.SerializeObject(response);
            return result;
        }
        #endregion
    }

}
