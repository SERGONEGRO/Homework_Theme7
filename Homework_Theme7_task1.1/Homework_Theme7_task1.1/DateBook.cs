using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_Theme7_task1._1
{
    /// <summary>
    /// Структура по работе с данными
    /// </summary>
    struct DateBook
    {
        private Record[] records; // Основной массив для хранения данных

        private string path; // путь к файлу с данными

        int index; // текущий элемент для добавления в records

        string[] titles; // массив, хранящий заголовки полей. используется в PrintDbToConsole

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Path">Путь в файлу с данными</param>
        public DateBook(string Path)
        {
            this.path = Path; // Сохранение пути к файлу с данными
            this.index = 0; // текущая позиция для добавления записи в records
            this.titles = new string[0]; // инициализаия массива заголовков   
            this.records = new Record[1]; // инициализаия массива записей.    | изначально предпологаем, что данных нет

            this.Load(); // Загрузка данных
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.records, this.records.Length * 2);
            }
        }

        /// <summary>
        /// Метод добавления записи в хранилище
        /// </summary>
        /// <param name="ConcreteRecord">Запись</param>
        public void Add(Record ConcreteRecord)
        {
            this.Resize(index >= this.records.Length);
            this.records[index] = ConcreteRecord;
            this.index++;
        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this.path,Encoding.Default))
            {
                titles = sr.ReadLine().Split(',');


                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Record(Convert.ToDateTime(args[0]),
                                           args[1], 
                                           Convert.ToInt32(args[2]),
                                           Convert.ToInt32(args[3]),
                                           args[4]));
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4]);

            File.Delete(path);
            File.AppendAllText(Path, $"{temp}\n",Encoding.UTF8);

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.records[i].Date,
                                        this.records[i].PartnerName,
                                        this.records[i].Income,
                                        this.records[i].PaymentAccount,
                                        this.records[i].Purpose);
                
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.WriteLine($"{this.titles[0],10} {this.titles[1],20} {this.titles[2],20} {this.titles[3],20} {this.titles[4],30}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.records[i].Print());
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Количество сотрудников в хранилище
        /// </summary>
        public int Count { get { return this.index; } }

    }
}
