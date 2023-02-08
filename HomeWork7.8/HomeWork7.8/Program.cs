using HomeWork_7._8;

namespace HomeWork_7
{
    internal class Program
    {
        /// <summary>
        /// Записывает данные о Worker в файл
        /// </summary>
        /// <param name="path"></param>
        static void WorkerWriter(string path)
        {
            string worker;
            Console.Write("ID: ");
            worker = Console.ReadLine() + "#";
            Console.Write("AddData: ");
            worker += DateTime.Now.ToString() + "#";
            Console.Write("FIO: ");
            worker += Console.ReadLine() + "#";
            Console.Write("Age: ");
            worker += Console.ReadLine() + "#";
            Console.Write("Height: ");
            worker += Console.ReadLine() + "#";
            Console.Write("Date of Birt: ");
            worker += Console.ReadLine() + "#";
            Console.Write("Place of Born: ");
            worker += Console.ReadLine();
            
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(worker);
            }
        }
       
        #region Сортировка
        /// <summary>
        /// Метод сортировки по ID
        /// </summary>
        /// <returns></returns>
        static Worker[] SortByID()
        {
            Worker[] workers = Repository.GetAllWorkers();
            var sorted = workers.OrderBy(x => x.Id);
            return sorted.ToArray();
        }

        /// <summary>
        /// Метод сортировки по FIO
        /// </summary>
        /// <returns></returns>
        static Worker[] SortByFIO()
        {
            Worker[] workers = Repository.GetAllWorkers();
            var sorted = workers.OrderBy(x => x.FIO);
            return sorted.ToArray();
        }
        #endregion

        /// <summary>
        /// Декоративный метод для уобного "интерфейса"
        /// </summary>
        static void FinishLine()
        {
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.Green;            
            Console.WriteLine("Нажмите на любую клавишу чтобы продолжить");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void Main(string[] args)
        {            
            Repository repos = new Repository();
            Repository.path = @"Workers.txt";
            Worker worker = new Worker();           

            byte on = 1;
            Console.WriteLine("Приветсвую!");
            while (on > 0)
            {
                Console.WriteLine("Введите символ для работы с данными,");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Символы:");
                Console.ResetColor();
                Console.WriteLine("1 - Просмотр всех записей");
                Console.WriteLine("2 - Просморт одной записи по ID");
                Console.WriteLine("3 - Создание записи и добваление записи в конец файла");
                Console.WriteLine("4 - Удаление одной записи по ID");
                Console.WriteLine("5 - Загрузка записей в выбранном диапазоне дат");
                Console.WriteLine("6 - Сортировка по ID");
                Console.WriteLine("7 - Сортировка по FIO");
                Console.WriteLine("8 - Просмотр пути файла");
                Console.WriteLine("9 - Очистить консоль");
                Console.WriteLine("0 - Выйти из программы\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите символ: ");
                byte changeMode = byte.Parse(Console.ReadLine());
                Console.ResetColor();                
                
                switch (changeMode)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Просмотр всех записей...");
                        Console.ResetColor();

                        Worker[] workers = Repository.GetAllWorkers();
                        foreach (var item in workers)
                        {
                            worker.WorkerPrint(item);
                        }
                        FinishLine();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Просмотр одной записей...");
                        Console.ResetColor();

                        Console.Write("Введите ID записи: ");
                        byte id = byte.Parse(Console.ReadLine());
                        worker.WorkerPrint((repos.GetWorkerById(id)));
                        FinishLine();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Создание записи и добваление записи в конец файла...");
                        Console.ResetColor();

                        repos.AddWorker(worker);
                        FinishLine(); 
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Удаление одной записи по ID...");
                        Console.ResetColor();

                        Console.Write("Введите ID записи который хотите удалить: ");
                        id = byte.Parse(Console.ReadLine());
                        repos.DeleteWorker(id);
                        Console.WriteLine("Запись удалена...");
                        FinishLine();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Загрузка записей в выбранном диапазоне дат...");
                        Console.ResetColor();

                        Console.Write("Введите начало даты в формате *день.месяц.год час.минут.секунд*: ");
                        DateTime dataFrom = DateTime.Parse(Console.ReadLine());
                        Console.Write("Введите конец даты в формате *день.месяц.год час.минут.секунд*: ");
                        DateTime dataTo = DateTime.Parse(Console.ReadLine());

                        workers = repos.GetWorkersBetweenTwoDates(dataFrom, dataTo);
                        foreach (var item in workers)
                        {
                            worker.WorkerPrint(item);
                        }
                        FinishLine();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Сортировка по ID...");
                        Console.ResetColor();

                        foreach (var item in SortByID())
                        {
                            worker.WorkerPrint(item);
                        }
                        FinishLine();
                        break; 
                    
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Сортировка по FIO...");                        
                        Console.ResetColor();
                        foreach (var item in SortByFIO())
                        {
                            worker.WorkerPrint(item);
                        }
                        FinishLine();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Red;
                        string test = repos.PathOfFile();
                        Console.WriteLine($"Путь файла: {test}");
                        Console.ResetColor();
                        FinishLine();
                        break;
                    
                    case 9:
                        Console.Clear();
                    break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выход...");
                        Console.ResetColor();
                        on = 0;
                    break;

                    default:   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекоректный символ, пожалуйста введите обратно: ");
                        Console.ResetColor();
                        FinishLine();
                        break;
                }
            }            
        }
    }
}