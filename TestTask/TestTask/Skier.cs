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
        /// Стартовое время. Задается [0] - часы, [1] - минуты, [2] - секунды.
        /// </summary>
        public byte[] StartTime { get; set; }

        /// <summary>
        /// Финишное время. Задается [0] - часы, [1] - минуты, [2] - секунды.
        /// </summary>
        public byte[] FinishTime { get; set; }

        /// <summary>
        /// Результат гонки. Задается [0] - часы, [1] - минуты, [2] - секунды.
        /// </summary>
        public byte[] ResultTime { get; private set; }

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
            StartTime = new byte[3] { startHour, startMinute, startSecond };
            FinishTime = new byte[3] { endHour, endMinute, endSecond };
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
        private int InSeconds(byte hour, byte minute, byte second)
        {
            return hour * 3600 + minute * 60 + second;
        }

        /// <summary>
        /// Приведение из секунд в часы, минуты и секунды.
        /// </summary>
        /// <param name="seconds">Количество секунд</param>
        private byte[] FromSeconds(int seconds)
        {
            byte[] result = new byte[3];

            result[0] = (byte) (seconds / 3600);
            seconds -= result[0] * 3600;

            result[1] = (byte) (seconds / 60);
            seconds -= result[1] * 60;

            result[2] = (byte) seconds;

            return result;
        }

        /// <summary>
        /// Вычисляет, за сколько времени лыжник проехал гонку и выводит результат на экран.
        /// </summary>
        public void Result()
        {
            // Если гонка проходила в полночь, нужно добавить 24 часа для правильного подсчета времени.
            byte finishHour = (byte)(StartTime[0] > FinishTime[0] ? FinishTime[0] + 24 : FinishTime[0]); 

            Console.WriteLine($"Лыжник {Name} стартовал в {string.Join(":", StartTime)}");
            Console.WriteLine($"Финишировал в {string.Join(":", FinishTime)}");

            int startTime = InSeconds(StartTime[0], StartTime[1], StartTime[2]);
            int endTime = InSeconds(finishHour, FinishTime[1], FinishTime[2]);

            int result = endTime - startTime;
            ResultTime = FromSeconds(result);

            Console.WriteLine($"Итоговое время: {string.Join(":", ResultTime)}");
        }
        #endregion
    }
}
