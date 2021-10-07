using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme7_task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encoding encCyr = Encoding.GetEncoding("Windows-1251");

            string path = @"data.csv";

            DateBook dateBook = new DateBook(path);

            dateBook.PrintDbToConsole();
            Console.WriteLine(dateBook.Count);

            dateBook.Add(new Record(DateTime.Now, "Kitaec", 10000, 7732177, "Teplaya kitaiskaya kurtka"));

            dateBook.PrintDbToConsole();
            Console.WriteLine(dateBook.Count);

            dateBook.Save("newdata.csv");

            Console.ReadKey();
        }
    }
}
