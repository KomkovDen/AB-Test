using System;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI
{
    //Класс для проведения эксперимента.
    public class ColorExperimentator : IExperimentator
    {
        #region PrivateField
        private IExperimentsRepository _experimentRepository;
        #endregion

        #region Constructor
        public ColorExperimentator(IExperimentsRepository repository)
        {
            _experimentRepository = repository;
        }
        #endregion

        #region Method
        public async Task<Experiment> GetExperimentResultAsync(Guid deviceToken)
        {   //Шаг 1 - Проверяем данный deviceID на присутствие в базе данных.При наличии такового - возвращаем результат из базы.
            //Шаг 2 - Генерируем новый экземпляр класса "Experiment" .
            //Шаг 3 - Сохраняем результат в базу данных.
            //Проверяем работу счётчика экспериментов и обнуляем его при необходимости.
            //Возвращаем результат.

            var experiment = await _experimentRepository.GetExperiment(deviceToken);
            if (experiment == null)
            {
                
                ColorExperimentResults._requestCounter++;
                var colorCode = ColorExperimentResults._requestCounter switch
                {
                    1 => ColorExperimentResults.FirstColor,
                    2 => ColorExperimentResults.SecondColor,
                    3 => ColorExperimentResults.ThirdColor,
                    _ => ""
                };

                var colorName = colorCode.ToString() switch
                {
                    "#FF0000" => "Red",
                    "#00FF00" => "Green",
                    "#0000FF" => "Blue",
                    _ => ""
                };

                experiment = new Experiment()
                {
                    Value = colorCode,
                    DeviceToken = deviceToken,
                    ColorGroup = colorName
                };

                await _experimentRepository.AddExperimentAsync(experiment);

                if (ColorExperimentResults._requestCounter == 3)
                {
                    ColorExperimentResults._requestCounter = 0;
                }
            }
            return experiment;
        }
        #endregion
    }
} 
