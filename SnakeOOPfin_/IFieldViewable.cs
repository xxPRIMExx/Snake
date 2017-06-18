using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOOP
{
    public interface IFieldViewable
    {
        void Run(UserAction action);
        void CreateField();
        void Initialize();
        Cell this[int pos1, int pos2] { get; }
        int Width { get; }
        int Height { get; }
        bool IsGameOver();
    }
}
