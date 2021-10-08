﻿using System;
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
        static string path = @"data.csv";
        static string source = @"source.csv";

        static void Main(string[] args)
        {
            

            string answer="1";
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t----ВЫБЕРИТЕ ПУНКТ МЕНЮ----\n");
                Console.WriteLine("1 - Показать все записи \n2 - Создание новой записи \n3 - Редактирование записи \n" +
                                  "4 - Удаление записей \n5 - Упорядочивание записей \n0 - ВЫХОД");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        {
                            Console.Clear();

                            DateBook dateBook = new DateBook(path);

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
                                Console.WriteLine("загрузка из файла");
                            }
                            else
                            {
                                ManualAdd();
                            }
                            
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Редактирование записи");
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Удаление записей");
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Упорядочивание записей");
                            Console.ReadKey();
                            break;
                        }
                    default: break;
                }
                

                //DateBook dateBook = new DateBook(path);

                //dateBook.PrintDbToConsole();
                //Console.WriteLine(dateBook.Count);

                //dateBook.Add(new Record(DateTime.Now, "Kitaec", 10000, 7732177, "Teplaya kitaiskaya kurtka"));

                //dateBook.PrintDbToConsole();
                //Console.WriteLine(dateBook.Count);

                //dateBook.Save("newdata.csv");

                //Console.ReadKey();
            } 
            while (answer != "0");
        }


        /// <summary>
        /// Ввод числа 
        /// </summary>
        /// <returns>число</returns>
        static int EnterNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число");
            }
            return number;
        }

        /// <summary>
        /// Ручное добавление записи
        /// </summary>
        static void ManualAdd()
        {
            DateBook dateBook = new DateBook(path);

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

        static void FileAdd()
        {
            DateBook dateBook = new DateBook(path);
            DateBook sourceBook = new DateBook(source);
        }
    }


}
