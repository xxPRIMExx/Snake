using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v2";                     // Заголовок консоли
            
            Field f = new Field();          // Инициализация поля
            View v = new View(f);           // Первичное отображение поля

            UserAction action = UserAction.Left;            // Задание начального движения змейки

            f.Initialize();                                 // Первичная инициализация игровых компонентов
            do
            {
                v.ShowField();                              // Отображение игрового поля
                f.Run(action);                              // Запуск игры

                if (Console.KeyAvailable)
                {
                    action = Control.GetUserAction();       // Считывание активности пользователя
                }
                
            } while (f.IsGameOver());                       // Завершение игры по действиям пользователя

            Console.SetCursorPosition(45, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.SetCursorPosition(45, 13);
            Console.WriteLine("Your Score: {0}", f.Score);
            Console.SetCursorPosition(0, 24);
        }
    }
}
