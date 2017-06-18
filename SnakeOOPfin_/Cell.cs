using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public abstract class Cell
    {

        protected Coordinate _coord;

        protected int _number;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

    }
}
