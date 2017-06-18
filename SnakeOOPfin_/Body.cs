using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public class Body : Cell
    {
        public Body(int i, int j)
        {
            _coord = new Coordinate(i, j);
        }
        public Body(Coordinate c)
        {
            _coord = c;
        }
    }
}
