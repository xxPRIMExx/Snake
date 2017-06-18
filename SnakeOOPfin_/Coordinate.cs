using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public class Coordinate
    {
        public Coordinate(int i  = 0, int j = 0)
        {
            _x = i;
            _y = j;
        }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                    _y = value;
            }
        }


        protected int _x = 0;
        protected int _y = 0;
    }
}
