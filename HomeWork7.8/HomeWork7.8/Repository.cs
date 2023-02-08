using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._8
{
    internal class Repository
    {
        public static string path { get; set; } //Путь файла

        /// <summary>
        /// Получение всех worker в виде массива структуры Worker
        /// </summary>
        /// <param name="sortChange">Для выбора режима сортировки</param>
        /// <returns></returns>
        public static Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров            
            using (StreamReader reader = new StreamReader(path))
            {
                string line; //для хранение строки линий файла
                Worker[] workers = new Worker[CountLinesInFile(path)]; //количество элементов worker зависит он линий читаемого файла
                int count = 0; //индекс элементов worker

                while ((line = reader.ReadLine()) != null)
                {
                    Worker worker = new Worker(); // worker который будет входить в виде элемента массива workers[]

                    string[] array = line.Split('#'); //в этом массиве будут храниться строки из линий файла раздельными #, array[0] = ID worker
                    worker.Id = int.Parse(array[0]);
                    worker.AddData = DateTime.Parse(array[1]);
                    worker.FIO = array[2];
                    worker.Age = int.Parse(array[3]);
                    worker.Height = int.Parse(array[4]);
                    worker.DateOfBirth = array[5];
                    worker.PlaceOfBorn = array[6];

                    workers[count] = worker;
                    count++; //След элемент массива workers[] в виде worker
                }
                return workers;
            }

        }        

        /// <summary>
        /// Получение worker с заданным ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker worker = new Worker();
            Worker[] workers = GetAllWorkers();
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].Id == id)
                {
                    worker = workers[i];                    
                    break;
                }                
            }
            if (worker.Id != id)
            {
                Console.BackgroundColor= ConsoleColor.Red;
                Console.WriteLine("Такого пользвателя не существует");
                Console.ResetColor();
            } 
            return worker;
        }

        /// <summary>
        /// Перезаписывает данные без worker которого удалили по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
            Worker[] workers = GetAllWorkers(); //Массив из структуры worker
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < workers.Length; i++)
                {                    
                    if (workers[i].Id == id) continue;
                    writer.WriteLine(workers[i].ToString());
                }
            }
        }

        /// <summary>
        /// Добавляет worker в конец файла
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            // 
            Console.Write("ID: ");
            worker.Id = int.Parse(Console.ReadLine());
            Console.Write("AddData: ");
            worker.AddData = DateTime.Now;
            Console.Write("FIO: ");
            worker.FIO = Console.ReadLine();
            Console.Write("Age: ");
            worker.Age = int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            worker.Height = int.Parse(Console.ReadLine());
            Console.Write("Date of Birt: ");
            worker.DateOfBirth = Console.ReadLine();
            Console.Write("Place of Born: ");
            worker.PlaceOfBorn = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(worker.ToString());
            }
        }

        /// <summary>
        /// Получение всех worker в указанном отрезке времени
        /// </summary>
        /// <param name="dateFrom">Дата от</param>
        /// <param name="dateTo">Дата до</param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers();
            Worker[] workers1 = new Worker[0];
            Worker worker;

            int count = 0; //Для количество элементов возвращаемого массива
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].AddData >= dateFrom && workers[i].AddData <= dateTo)
                {
                    Array.Resize(ref workers1, count+1);//увеличиваем массив на 1 элемент при нахождений сотрудника
                    //Console.WriteLine(workers[i]);
                    worker = workers[i];

                    workers1[count] = worker;
                    count++;

                }
            }            
            return workers1;
        }

        /// <summary>
        /// Возвращает путь файла в виде string
        /// </summary>
        /// <returns></returns>
        public string PathOfFile()
        {
            using (FileStream reader = File.OpenRead(path))
            {
                string path = reader.Name;
            }
            return path;
        }

        /// <summary>
        /// Вспомогательный методля для получения количества строк в файле
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static int CountLinesInFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int count = 0; //Количество линий в файле
                while(reader.ReadLine() != null) //Пока читаемые линий не достигнет null
                {
                    count++;
                }
                return count;
            }
        }  
    }
}
