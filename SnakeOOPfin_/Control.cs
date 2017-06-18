using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    /// <summary>
    /// Описание возможных действий пользователя
    /// </summary>

    public enum UserAction
    {
        NoAction,
        Left,
        Right,
        Exit,
        Top,
        Bottom
    }

    class Control
    {
        /// <summary>
        /// Считывание действия пользователя
        /// </summary>
        /// <returns>Метод возвращает текущий выбор</returns>
        public static UserAction GetUserAction()
        {
            UserAction action = UserAction.NoAction;

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    action = UserAction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    action = UserAction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    action = UserAction.Top;
                    break;
                case ConsoleKey.DownArrow:
                    action = UserAction.Bottom;
                    break;
                case ConsoleKey.Escape:
                    action = UserAction.Exit;
                    break;
            }
            return action;
        }
    }
}
