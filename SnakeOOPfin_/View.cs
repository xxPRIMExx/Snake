using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    class View
    {
        public View(IFieldViewable f)
        {
            _field = f;
        }

        /// <summary>
        /// Отображение игрового поля
        /// </summary>
        public void ShowField()
        {
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    GetSymbolAndColorByCell(i, j);
                }
                Console.WriteLine();
            } 
        }

        /// <summary>
        /// Отрисовка змейки и поля  // Для оптимизации быстродействия можно было сделать проверку на AS
        /// </summary>
        /// <param name="i"> положение по Х</param>
        /// <param name="j"> положение по Y </param>
        private void GetSymbolAndColorByCell(int i, int j)
        {

            Console.SetCursorPosition(i, j);

            if (_field[i, j] is Obstacle)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('#');
            } 
            if (_field[i, j] is Head)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('@');
            } 
            if (_field[i, j] is Body)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write('*');
            } 
            if (_field[i, j] is Food)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('+');
            } 

            if (_field[i, j] == null)
            {
#if DEBUG
                Console.ForegroundColor = ConsoleColor.White;                
#else
                Console.ForegroundColor = ConsoleColor.Black;
#endif
                Console.SetCursorPosition(i, j);
                Console.Write('~');
                //} // end if
            } // end for (j)
        }

#if DEBUG
            ///// <summary>
            ///// Функция осуществляющая считывание действий пользователя
            ///// </summary>
            ///// <returns>Возвращает нажатую клавишу</returns>
            //public static UserAction GetUserAction()
            //{
            //    UserAction action = UserAction.NoAction;
            //    ConsoleKeyInfo key = Console.ReadKey();

            //    switch (key.Key)
            //    {
            //        case ConsoleKey.LeftArrow:
            //            action = UserAction.Left;
            //            break;
            //        case ConsoleKey.RightArrow:
            //            action = UserAction.Right;
            //            break;
            //        case ConsoleKey.UpArrow:
            //            action = UserAction.Top;
            //            break;
            //        case ConsoleKey.DownArrow:
            //            action = UserAction.Bottom;
            //            break;
            //        case ConsoleKey.Escape:
            //            action = UserAction.Exit;
            //            break;
            //    }
            //    return action;
            //}
#endif
            IFieldViewable _field = null;
        }

    }
//}

