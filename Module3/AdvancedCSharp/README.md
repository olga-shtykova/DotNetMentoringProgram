**Задания к модулю Advanced CSharp**

Задание 1.

Создайте класс FileSystemVisitor, который позволяет обходить дерево папок в файловой системе, начиная с указанной точки.

Перед реализацией обсудить с ментором какой будет уровень представления (консольное или Desktop приложение).

Указанный класс должен:

- Возвращать все найденные файлы и папки в виде линейной последовательности, для чего реализовать свой итератор (по возможности используя оператор yield)

- Давать возможность задать алгоритм фильтрации найденных файлов и папок в момент создания экземпляра FileSystemVisitor (через специальный перегруженный конструктор). Алгоритм должен задаваться в виде делегата/лямбды

- Генерировать уведомления (через механизм событий) об этапах своей работы. В частности, должны быть реализованы следующие события (имена событий могут быть любыми главное, чтобы они соответствовали соглашению по именованию)

- Start и Finish (для начала и конца поиска)

- FileFound/DirectoryFound для всех найденных файлов и папок до фильтрации, и FilteredFileFound/filteredDirectoryFound для файлов и папок, прошедших фильтрацию. Данные события должны позволять (через установку специальных флагов в переданных параметрах):

- прервать поиск
- исключить файлы/папки из конечного списка

Задание 2.

Напишите библиотеку модульных тестов, демонстрирующих различные режимы работы FileSystemVisitor. Необходимость использования моков (mock) согласуйте с ментором.