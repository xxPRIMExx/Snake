using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public class Obstacle : Cell
    {
        /// <summary>
        /// Создание препятствия по координатам
        /// </summary>
        /// <param name="i">координата по Х</param>
        /// <param name="j">координата по Y</param>
        public Obstacle(int i, int j)
        {
            _coord = new Coordinate(i, j);
            _number++;
        }

    }
}
