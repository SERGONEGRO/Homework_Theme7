using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme7_task1._1
{
    struct Record
    {
        #region Поля

        /// <summary>
        /// Дата
        /// </summary>
        DateTime date;

        /// <summary>
        /// Имя Партнера
        /// </summary>
        string partnerName;

        /// <summary>
        /// Сумма платежа
        /// </summary>
        int income;

        /// <summary>
        /// Счёт плательщика
        /// </summary>
        int paymentAccount;

        /// <summary>
        /// Назначение платежа
        /// </summary>
        string purpose;

        #endregion

        #region Свойства

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime Date { get { return this.date; } set { this.date = value; } }

        /// <summary>
        /// Имя партнера
        /// </summary>
        public string PartnerName { get { return this.partnerName; } set { this.partnerName = value; } }

        /// <summary>
        /// Назначение перевода
        /// </summary>
        public string Purpose { get { return this.purpose; } set { this.purpose = value; } }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        public int Income { get { return this.income; } set { this.income = value; } }

        /// <summary>
        /// Счёт плательщика
        /// </summary>
        public int PaymentAccount { get {return this.paymentAccount } set { this.paymentAccount = value; } }

        #endregion

        #region Конструкторы

       /// <summary>
       /// Создание записи 
       /// </summary>
       /// <param name="Date">Дата сделки</param>
       /// <param name="PartnerName">Имя партнера</param>
       /// <param name="Income">Сумма платежа</param>
       /// <param name="PaymentAccount">Счет плательщика</param>
       /// <param name="Purpose">Назначение</param>
        public Record(DateTime Date, string PartnerName, int Income, int PaymentAccount, string Purpose)
        {
            this.date = Date;
            this.partnerName = PartnerName;
            this.income = Income;
            this.paymentAccount = PaymentAccount;
            this.purpose = Purpose;
        }

        /// <summary>
        /// Создание записи 
        /// </summary>
        /// <param name="Date">Дата сделки</param>
        /// <param name="PartnerName">Имя партнера</param>
        /// <param name="Income">Сумма платежа</param>
        /// <param name="PaymentAccount">Счет плательщика</param>
        public Record(DateTime Date, string PartnerName, int Income, int PaymentAccount)
        {
            this.date = Date;
            this.partnerName = PartnerName;
            this.income = Income;
            this.paymentAccount = PaymentAccount;
            this.purpose = string.Empty;
        }

        /// <summary>
        /// Создание записи 
        /// </summary>
        /// <param name="Date">Дата сделки</param>
        /// <param name="PartnerName">Имя партнера</param>
        /// <param name="Income">Сумма платежа</param>
        public Record(DateTime Date, string PartnerName, int Income)
        {
            this.date = Date;
            this.partnerName = PartnerName;
            this.income = Income;
            this.paymentAccount = 123;
            this.purpose = string.Empty;
        }

        /// <summary>
        /// Создание записи 
        /// </summary>
        /// <param name="Date">Дата сделки</param>
        /// <param name="Income">Сумма платежа</param>
        public Record(DateTime Date, int Income)
        {
            this.date = Date;
            this.partnerName = "Валдис";
            this.income = Income;
            this.paymentAccount = 123456;
            this.purpose = "Партия тракторов К-700";
        }


        #endregion

        #region Методы

        /// <summary>
        /// Печатать запись
        /// </summary>
        /// <returns>строка записи</returns>
        public string Print()
        {
            return $"{this.date,15} {this.partnerName,15} {this.income,15} {this.paymentAccount,15} {this.purpose,10}";
        }

        #endregion

    }
}
