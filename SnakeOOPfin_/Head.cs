using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public class Head : Cell
    {
        public Head()
        {

        }
        public Head(int i, int j) : base()
        {
            _coord = new Coordinate(i, j);
        }

        public int CoordX
        {
            get
            {
                return _coord.X;
            }
            set
            {
                _coord.X = value;
            }
        }

        public int CoordY
        {
            get
            {
                return _coord.Y;
            }
            set
            {
                _coord.Y = value;
            }
        }

        public Coordinate GetCoord
        {
            get
            {
                return _coord;
            }
            set
            {
                _coord = value;
            }
        }
    }
}
