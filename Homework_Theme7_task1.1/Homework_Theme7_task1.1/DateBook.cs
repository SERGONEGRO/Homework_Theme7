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
        public Record[] records; // Основной массив для хранения данных

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
            this.records = new Record[1]; // инициализация массива записей.    | изначально предпологаем, что данных нет

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
            using (StreamReader sr = new StreamReader(this.path, Encoding.Default))
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
            File.AppendAllText(Path, $"{temp}\n", Encoding.Default);

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.records[i].Date,
                                        this.records[i].PartnerName,
                                        this.records[i].Income,
                                        this.records[i].PaymentAccount,
                                        this.records[i].Purpose);

                File.AppendAllText(Path, $"{temp}\n", Encoding.Default);
            }
        }

        /// <summary>
        /// Изменение заданной строки
        /// </summary>
        /// <param name="recNum">Номер записи</param>
        /// <param name="Path">Путь к файлу</param>
        public void ChangeRecord(int index, string partName, int inc, int acc, string purp)
        {
            this.records[index].Date = DateTime.Now;
            this.records[index].PartnerName = partName;
            this.records[index].Income = inc;
            this.records[index].PaymentAccount = acc;
            this.records[index].Purpose = purp;

        }

        /// <summary>
        /// Удаляет все строки
        /// </summary>
        public void DeleteRecords()
        {
            records = new Record[1];
            
            this.index = 0;
            
        }


        /// <summary>
        /// Удаляет заданную строку
        /// </summary>
        /// <param name="i">номер строки</param>
        public void DeleteRecords(int numDel)
        {
            List<Record> tmp = new List<Record>(records);
            tmp.RemoveAt(numDel);
            records = tmp.ToArray();
            index--;
        }

        /// <summary>
        /// Упорядочивает записи по Дате
        /// </summary>
        public void OrderRecords()
        {
            List<Record> tmp = new List<Record>(records);
            tmp.RemoveRange(index,tmp.Count-index);   //удаляем пустые значения
            
            var sortedTmp = from r in tmp
                            orderby r.Date
                            select r;
            
            records = sortedTmp.ToArray();
            
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.WriteLine($"{this.titles[0],10} {this.titles[1],20} {this.titles[2],20} {this.titles[3],20} {this.titles[4],30}");
            
            //records = records.Where(x => x != null).ToArray();
            if (this.records.Length>0 )
            {
                for (int i = 0; i < index; i++)
                    { 
                        Console.WriteLine($"{i + 1}  {this.records[i].Print()}");
                        Console.WriteLine();
                    }
                        
                   
            }
        }

        /// <summary>
        /// Количество сотрудников в хранилище
        /// </summary>
        public int Count { get { return this.index; } }
   }
}

    


