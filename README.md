# AB-Test
Для работы с приложением воспользуйтесь программой Postman или Swagger.
Сконфигурируйте GET-запрос следующим образом: "https://localhost:5001/Experiments?"Ключ"="Значение"
Ключ=deviceToken Значение="guid" (Guid - случайное значение сгенерированное приложением,а не строковое значение из четырёх букв).
Получите ответ от приложения в формате JSON. В нём будут содержаться значение одного из трёх цветов: Red,Green,Blue; 
и соответствующая кодировка цвета: "#FF0000","#00FF00","#0000FF".
Для отображения общей статистики результатов проведённых экспериментов обратитесь по ссылке: "https://localhost:5001/ExperimentsObserver"
На данной странице будет отображены три группы , на которые будут разделены все устройства* принимающие участие в проведении теста.
Также, в конце страницы отображается счётчик общего количества экспериментов.
*Под термином устройство подразумевается уникальный Guid-ключ, который поступает при запросе и сохраняется в базе данных
в качестве идентификатора устройства обратившегося к данному API.

В написании данного решения были использованы следующие технологии: EF Core, Repository-Pattern, MS SQL Server, Dependency Injection.
Также, при необходимости, Вы можете легко сменить тип БД благодаря слабосвязанному коду и интерфейсов для взаимодействия с моделями.
