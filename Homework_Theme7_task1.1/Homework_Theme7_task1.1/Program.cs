using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Разработать ежедневник.
/// В ежедневнике реализовать возможность 
/// - создания
/// - удаления
/// - реактирования 
/// записей
/// 
/// В отдельной записи должно быть не менее пяти полей
/// 
/// Реализовать возможность 
/// - Загрузки даннах из файла
/// - Выгрузки даннах в файл
/// - Добавления данных в текущий ежедневник из выбранного файла
/// - Импорт записей по выбранному диапазону дат
/// - Упорядочивания записей ежедневника по выбранному полю

namespace Homework_Theme7_task1._1
{
    class Program
    {
        static string path = @"data.csv";          //путь к основному файлу
        static string source = @"source.csv";      //путь к файлу, из которого данные загружаются в основной файл

        static void Main(string[] args)
        {
            DateBook dateBook = new DateBook(path);

            string answer="1";
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t----ВЫБЕРИТЕ ПУНКТ МЕНЮ----\n");
                Console.WriteLine("1 - Показать все записи \n2 - Создание новой записи \n3 - Редактирование записи \n" +
                                  "4 - Удаление записей \n5 - Упорядочивание записей \n6 - СОХРАНИТЬ ИЗМЕНЕНИЯ\n0 - ВЫХОД");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        {
                            Console.Clear();

                            dateBook.PrintDbToConsole();
                            Console.WriteLine($"\n\tВСЕГО ЗАПИСЕЙ: {dateBook.Count}") ;
                            Console.ReadKey();

                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Если нужно загрузить из файла, нажмите 1.\nЕсли нужно загрузить вручную, нажмите любую кнопку.");

                            if( Console.ReadLine()=="1")
                            {
                                DateBook sourceBook = new DateBook(source);
                                
                                foreach (Record rec in sourceBook.records)
                                {
                                    dateBook.Add(rec);
                                }

                                Console.WriteLine($"Добавлено записей: {sourceBook.Count}");
                            }
                            else
                            {
                                Console.WriteLine("\tВведите имя партнера:");
                                string partName = Console.ReadLine();
                                Console.WriteLine("\tВведите сумму платежа:");
                                int incom = EnterNumber();
                                Console.WriteLine("\tНомер счета:");
                                int account = EnterNumber();
                                Console.WriteLine("\tЦель платежа:");
                                string purp = Console.ReadLine();

                                dateBook.Add(new Record(DateTime.Now, partName, incom, account, purp));

                                dateBook.Save(path);
                                Console.WriteLine("Запись добавлена!");
                            }
                            
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();

                            int recordNumber;

                            do
                            {
                                Console.WriteLine("Введите номер записи для редактирования:");
                                recordNumber = EnterNumber() - 1;
                            }
                            while (dateBook.records.Length < recordNumber || recordNumber < 1);

                            Console.WriteLine($"Редактируется запись:\n{dateBook.records[recordNumber].Print()}");
                           


                            Console.WriteLine("Введите имя партнера:");
                            string tempPartnerName = Console.ReadLine();

                            Console.WriteLine("Введите Сумму:");
                            int tempIncome = Program.EnterNumber();

                            Console.WriteLine("Введите Платежный счет:");
                            int tempPaymentAccount = Program.EnterNumber();

                            Console.WriteLine("Введите назначение платежа:");
                            string tempPurpose = Console.ReadLine();


                            dateBook.ChangeRecord(recordNumber,tempPartnerName,tempIncome,tempPaymentAccount,tempPurpose);
                            Console.WriteLine("Запись изменена!");

                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                           
                            Console.WriteLine("Если нужно удалить все, введите ALL");

                            if (Console.ReadLine() == "ALL")
                            {
                                dateBook.DeleteRecords();
                                break;
                            }
                            else
                            {
                                int answerDel;
                                if (dateBook.Count > 0)
                                {
                                    do
                                    {
                                        Console.WriteLine("Введите номер записи, которую хотите удалить:");
                                        answerDel = EnterNumber();
                                    }
                                    while (dateBook.Count < answerDel || answerDel < 1);

                                    dateBook.DeleteRecords(answerDel - 1);
                                    Console.WriteLine("Запись удалена!");

                                }
                                else Console.WriteLine("Нет записей для удаления");

                                
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            dateBook.OrderRecords();
                            Console.WriteLine("Упорядочивание записей завершено");
                            Console.ReadKey();
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            dateBook.Save(path);
                            Console.WriteLine("Все изменения сохранены!");
                            Console.ReadLine();
                            break;
                        }
                    default: break;
                }
          
            } 
            while (answer != "0");
        }


        /// <summary>
        /// Ввод числа 
        /// </summary>
        /// <returns>число</returns>
        static public int EnterNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число");
            }
            return number;
        }

       
    }


}
