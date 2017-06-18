using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeOOP
{
    public enum FieldItems
    {
        Empty,
        SnakeBody,
        SnakeHead,
        Food
    }

    public class Field : IFieldViewable
    {
        Random rand = new Random();
        public Field(byte higth = 44, byte width = 24) 
        {
            _height = higth;
            _width = width;
            _snakeCoord = new Coordinate[_height * _width];
        }

        public void CreateField()
        {
            _height = 44;
            _width = 24;
            _snakeCoord = new Coordinate[_height * _width];

        }
        /// <summary>
        /// Процедура запуска игры "Змейка"
        /// </summary>
        public void Initialize()
        {
            _currentSnakeLength = _snakeInitializeLength;       // Задание начальной длины змейки

            CreateNewField();                                   // Создание игрового поля
            
            AddHeadOnTheField();        // Добавление головы змейки на поле
            AddBodyOnTheField();        // Добавление тела змейки длинной _currentSnakeLength на поле
            AddFoodOnTheField();        // Добавление еды на поле
        }


        /// <summary>
        /// Метод для управления змейкой
        /// </summary>
        /// <param name="action"> нажатие клавиши </param>
        public void Run(UserAction action)
        {
            if(!IsFoodExist())          // Если еда не существует (была съедена)
            {
                AddFoodOnTheField();        // Добавление новой еды
                AddBodyOnTheField();        // Добавлен ячейки тела, т.к. еда была съедена
            }

            switch (action)
            {
                case UserAction.Left:
                    SnakeMoving(-1, 0);
                    break;
                case UserAction.Right:
                    SnakeMoving(1, 0);
                    break;
                case UserAction.Top:
                    SnakeMoving(0, -1);
                    break;
                case UserAction.Bottom:
                    SnakeMoving(0, 1);
                    break;
                default:
                    break;
            }
    }

        /// <summary>
        /// Процедура создания поля с границами
        /// </summary>
        public void CreateNewField()
        {
            _cell = new Cell[_height, _width];                  // Создание поля размерностю _heigth x _width
            for (int i = 0; i < _cell.GetLength(0); i++)
            {
                for (int j = 0; j < _cell.GetLength(1); j++)
                {
                    if (isLeftSide(i, j)
                     || isRightSide(i, j)                         
                     || isTopSide(i, j)
                     || isBottomSide(i, j))
                    {
                        _cell[i, j] = new Obstacle(i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Инициализация "Головы" змейки на поле
        /// </summary>
        private void AddHeadOnTheField()
        {
            _cell[_height / 2, _width / 2] = new Head(_height / 2, _width / 2);     // Размещение головы в центре игрового поля
            _head = new Head(_height / 2, _width / 2);                              // Первичная инициализация координат головы
            _snakeCoord[0] = _head.GetCoord;
        }


        /// <summary>
        /// Процедура добавления "Тела змейки длинной _snakeLength - на игровое поле
        /// </summary>
        private void AddBodyOnTheField()
        {
            if (_snakeCoord[1] == null)                         // Первичная инициализация, тела змейки не существует
            {
                for (int i = 0; i < _currentSnakeLength; i++)
                {
                    _cell[_head.CoordX + (i + 1), _head.CoordY] = new Body(_head.CoordX + (i + 1), _head.CoordY);
                    _snakeCoord[i + 1] = new Coordinate(_head.CoordX + (i + 1), _head.CoordY);
                }
            }
            else                                               // Добавление еденичного елемента тела на поле
            {
                _currentSnakeLength++;
                _snakeCoord[_currentSnakeLength] = new Coordinate(_snakeCoord[0].X, _snakeCoord[0].Y);
                _cell[_snakeCoord[0].X, _snakeCoord[0].Y] = new Body(_snakeCoord[0].X, _snakeCoord[0].Y);

            }
        }


        /// <summary>
        /// проверка на наличие еды на поле
        /// </summary>
        private bool IsFoodExist()
        {
            bool isFood = false;

            for (int i = 0; i < _cell.GetLength(0); i++)
            {
                for (int j = 0; j < _cell.GetLength(1); j++)
                {
                    if (_cell[i, j] is Food)
                    {
                        isFood = true;
                        return isFood;
                    }
                }
            }
            return isFood;
        }
        /// <summary>
        /// Добавление еды в пустую ячейку
        /// </summary>
        private void AddFoodOnTheField()
        {
            int x = rand.Next(1, _height);
            int y = rand.Next(1, _width);
            if (!(_cell[x, y] is Head || _cell[x, y] is Body || _cell[x, y] is Obstacle))   // Еда должна быть помещена в пустую ячейку
            {                                                                               
                _cell[x, y] = new Food();
            }
        }

        /// <summary>
        /// Передвижение змейки по полю за одну итерацию
        /// </summary>
        /// <param name="dx">сдвиг по оси Х</param>
        /// <param name="dy">сдвиг по оси Y</param>
        public void SnakeMoving(int dx, int dy)
        {

#if DEBUG
            //_cell[_snakeCoord[_currentSnakeLength]] = null;
            //for (int i = _currentSnakeLength; i >= 1; i--)
            //{
            //    _snakeCoord[i] = _snakeCoord[i-1];
            //    _cell[_snakeCoord[_currentSnakeLength - i].X, _snakeCoord[_currentSnakeLength - i].Y] = new Body(_snakeCoord[_currentSnakeLength - i].X, _snakeCoord[_currentSnakeLength - i].Y);
            //    //_cell[_snakeCoord[_currentSnakeLength - i].X, _snakeCoord[_currentSnakeLength - i].Y] = null;
            //}
            ////_cell[_snakeCoord[_currentSnakeLength].X, _snakeCoord[_currentSnakeLength].Y] = null;

            //_head.CoordX += dx;
            //_head.CoordY += dy;
            //_snakeCoord[0] = _head.GetCoord;
            ////_cell[_head.CoordX - dx, _head.CoordY - dy] = new Body(_head.GetCoord);
            //_cell[_snakeCoord[0].X, _snakeCoord[0].Y] = new Head(_head.CoordX, _head.CoordY);
#endif
            #region Рабочая версия // отрефакторить

            _cell[_snakeCoord[_currentSnakeLength].X, _snakeCoord[_currentSnakeLength].Y] = null; // Затирание хвоста змейки

            for (int i = _currentSnakeLength; i >= 1; i--)
            {
                _snakeCoord[i].X = _snakeCoord[i - 1].X;
                _snakeCoord[i].Y = _snakeCoord[i - 1].Y;
                _cell[_snakeCoord[_currentSnakeLength - i].X, _snakeCoord[_currentSnakeLength - i].Y]
                    = new Body(_snakeCoord[_currentSnakeLength - i].X, _snakeCoord[_currentSnakeLength - i].Y); //расположение тела змейки на предыдущем
                                                                                                                //месте головы
            }
            _snakeCoord[0].X += dx;
            _snakeCoord[0].Y += dy;
            _cell[_snakeCoord[0].X, _snakeCoord[0].Y] = new Head(); // Расположение головы змейки на новом месте
            #endregion

        }



        /// <summary>
        /// Возвращает TRUE если змейка не находится на границах поля, позволяя продолжать игру
        /// Возвращает FALSE если змейка находится на границе поля, запрещая продолжение игры
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            return !(isBottomSide(_snakeCoord[0].X, _snakeCoord[0].Y)
                || isLeftSide(_snakeCoord[0].X, _snakeCoord[0].Y)
                || isRightSide(_snakeCoord[0].X, _snakeCoord[0].Y)
                || isTopSide(_snakeCoord[0].X, _snakeCoord[0].Y)
                || isBody());
        }

        #region DetectBorders
        /// <summary>
        /// Метод определяет нижнюю границу массива, для дальшейней отрисовки горизонтальной
        /// нижней линии
        /// </summary>
        /// <param name="FieldSpace">Игровое поле</param>
        /// <param name="i">индекс строки</param>
        /// <param name="j">индекс столбца</param>
        /// <returns> Нижняя граница поля достигнута</returns>
        private bool isBottomSide(int i, int j)
        {
            return j >= 0 && j < GetLength(1) - 1 && i == GetLength(0) - 1;
        }
        /// <summary>
        /// Метод определяет верхнюю границу массива, для дальшейней отрисовки горизонтальной
        /// верхней линии
        /// </summary>
        /// <param name="FieldSpace">Игровое поле</param>
        /// <param name="i">индекс строки</param>
        /// <param name="j">индекс столбца</param>
        /// <returns> Верхняя граница поля достигнута </returns>
        private bool isTopSide(int i, int j)
        {
            return j >  0 && j < GetLength(1) - 1 && i == 0;
        }
        /// <summary>
        /// Метод определяет правую границу массива, для дальшейней отрисовки 
        /// вертикальной правой линии
        /// </summary>
        /// <param name="FieldSpace">Игровое поле</param>
        /// <param name="i">индекс строки</param>
        /// <param name="j">индекс столбца</param>
        /// <returns> Правая граница поля достигнута </returns>
        private bool isRightSide(int i, int j)
        {
            return i >= 0 && i < GetLength(0) && j == GetLength(1) - 1;
        }
        /// <summary>
        /// Метод определяет левую границу поля
        /// вертикальной левой линии
        /// </summary>
        /// <param name="FieldSpace">Игровое поле</param>
        /// <param name="i">индекс строки</param>
        /// <param name="j">индекс столбца</param>
        /// <returns> Достижение левой границы</returns>
        private bool isLeftSide(int i, int j)
        {
            return i >= 0 && i < GetLength(0) -1 && j < 1 ;
        }

        /// <summary>
        /// Определение положения головы по отношению к телу
        /// Game Over = поpиция головы == позиция тела;
        /// </summary>
        /// <returns>Голова врезалась в тело</returns>
        private bool isBody()
        {
           bool isGameOver = false;

           for (int i = 1; i < _currentSnakeLength; i++)
           {
               if (_snakeCoord[0].X == _snakeCoord[i].X && _snakeCoord[0].Y == _snakeCoord[i].Y)
               {
                   isGameOver = true;
               }
           }
               return isGameOver;
        }
#endregion

        /// <summary>
        /// Переопределяем для удобства метод нахождения размерности массива
        /// </summary>
        /// <param name="dimension">N- мерность массива</param>
        /// <returns>Возвращает размер N - мерного массива</returns>
        
        //  enum Dimension { Height = 0, Width = 1 }
        public int GetLength(int dimension)
        {
            int size = 0;

            switch (dimension)
            {
                case 0:
                    size = _height;
                    break;
                case 1:
                    size = _width;
                    break;
                default:
                    size = -1;
                    break;
            }

            //if(dimension == 0)
            //{
            //    size = _height;
            //}
            //else if(dimension == 1)
            //{
            //    size = _width;
            //}

            return size;
        }
	



        #region Аксетторы (Нужны-ли??)
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value > 0 && value < byte.MaxValue)
                {
                    _height = value;
                }
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0 && value < byte.MaxValue)
                {
                    _width = value;
                }

            }
        }

        public uint Score
        {
            get
            {
                return _score = (uint)_currentSnakeLength - _snakeInitializeLength;
            }
        }
        #endregion

        #region Indexator
        public Cell this[int pos1, int pos2]
        {
            get
            {
                return _cell[pos1, pos2];
            }
            set
            {
                _cell[pos1, pos2] = value;
            }
        }

        // Почему не работает??
        public Cell this[Coordinate crd]
        {
            get
            {
                return _cell[crd.X, crd.Y];
            }
            set
            {
                _cell[crd.X, crd.Y] = value;
            }
        }
        #endregion
        
        
        private const int _snakeInitializeLength = 3;
        private int _currentSnakeLength;

        private uint _score = 0;

        private int _height = 0;
        private int _width = 0;

        private Coordinate[] _snakeCoord;

        private Food _food;
        private Cell[,] _cell;
        private Head _head;

    }
}
