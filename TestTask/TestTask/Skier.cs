using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Skier
    {
        #region Поля и свойства
        /// <summary>
        /// Имя лыжника.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер лыжника
        /// </summary>
        private static int number = 1; 

        /// <summary>
        /// Час старта гонки.
        /// </summary>
        public byte StartHour { get; set; }
        
        /// <summary>
        /// Минута старта гонки.
        /// </summary>
        public byte StartMinute { get; set; }
        
        /// <summary>
        /// Секунда старта гонки.
        /// </summary>
        public byte StartSecond { get; set; }
        
        /// <summary>
        /// Час финиша гонки.
        /// </summary>
        public byte EndHour { get; set; }

        /// <summary>
        /// Минута финиша гонки.
        /// </summary>
        public byte EndMinute { get; set; }
        
        /// <summary>
        /// Секунда финиша гонки.
        /// </summary>
        public byte EndSecond { get; set; }

        /// <summary>
        /// Результат гонки. Час.
        /// </summary>
        public byte ResultHour { get; private set; }
        
        /// <summary>
        /// Результат гонки. Минута.
        /// </summary>
        public byte ResultMinute { get; private set; }
        
        /// <summary>
        /// Результат гонки. Секунда.
        /// </summary>
        public byte ResultSecond { get; private set; }
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя лыжника</param>
        /// <param name="startHour">Час старта гонки</param>
        /// <param name="startMinute">Минута старта гонки</param>
        /// <param name="startSecond">Секунда старта гонки</param>
        /// <param name="endHour">Час финиша гонки</param>
        /// <param name="endMinute">Минута финиша гонки</param>
        /// <param name="endSecond">Секунда финиша гонки</param>
        public Skier(string name, byte startHour, byte startMinute, byte startSecond, byte endHour, byte endMinute, byte endSecond)
        {
            if (startHour > 23 || endHour > 23 || startMinute > 59 || endMinute > 59 || startSecond > 59 || endSecond > 59)
                throw new ArgumentException("Неправильное время");
            if (name == string.Empty)
                name = "Anonymous Skier № " + number;

            Name = name;
            StartHour = startHour;
            StartMinute = startMinute;
            StartSecond = startSecond;
            EndHour = endHour;
            EndMinute = endMinute;
            EndSecond = endSecond;
            number++;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Приведение часов, минут и секунд к секундам.
        /// </summary>
        /// <param name="hour">Часы</param>
        /// <param name="minute">Минуты</param>
        /// <param name="second">Секунды</param>
        /// <returns>Общее количество секунд.</returns>
        private long ToSecond(byte hour, byte minute, byte second)
        {
            return hour * 3600 + minute * 60 + second;
        }

        /// <summary>
        /// Приведение из секунд в часы, минуты и секунды.
        /// </summary>
        /// <param name="second">Количество секунд</param>
        private void ToResult(long second)
        {
            ResultHour = (byte) (second / 3600);
            second -= ResultHour * 3600;

            ResultMinute = (byte) (second / 60);
            second -= ResultMinute * 60;

            ResultSecond = (byte) second;
        }

        /// <summary>
        /// Вычисляет, за сколько времени лыжник проехал гонку и выводит результат на экран.
        /// </summary>
        public void Result()
        {
            // Если гонка проходила в полночь, нужно добавить 24 часа для правильного подсчета времени.
            byte endHour = (byte)(StartHour > EndHour ? EndHour + 24 : EndHour); 

            Console.WriteLine($"Лыжник {Name} стартовал в {StartHour}:{StartMinute}:{StartSecond}");
            Console.WriteLine($"Финишировал в {EndHour}:{EndMinute}:{EndSecond}");
            long startTime = ToSecond(StartHour, StartMinute, StartSecond);
            long endTime = ToSecond(endHour, EndMinute, EndSecond);

            long result = endTime - startTime;
            ToResult(result);

            Console.WriteLine($"Итоговое время: {ResultHour}:{ResultMinute}:{ResultSecond}");
        }
        #endregion
    }
}
