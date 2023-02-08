using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._8
{
    internal struct Worker
    {
        public int Id { get; set; }
        public DateTime AddData { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBorn { get; set; }

        /// <summary>
        /// Возвращает данные полей в виде string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id.ToString() + "#" + AddData.ToString() + "#" + FIO + "#" + Age.ToString() + "#" + Height.ToString() + "#" + DateOfBirth + "#" + PlaceOfBorn;
        }     
        
        /// <summary>
        /// Вывод данных полей Worker на консоль
        /// </summary>
        /// <param name="worker"></param>
        public void WorkerPrint(Worker worker)
        {
            Console.WriteLine($"ID: {worker.Id}");
            Console.WriteLine($"AddData: {worker.AddData}");
            Console.WriteLine($"FIO: {worker.FIO}");
            Console.WriteLine($"Age: {worker.Age}");
            Console.WriteLine($"Height: {worker.Height}");
            Console.WriteLine($"Data of birth: {worker.DateOfBirth}");
            Console.WriteLine($"Place of born: {worker.PlaceOfBorn}\n");
        }
    }
}
