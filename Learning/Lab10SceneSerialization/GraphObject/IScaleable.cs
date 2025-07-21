using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphObject
{
    public interface IScaleable // нечто маштабируемое
    {
        // public abstract
        void Scale(double scale);

        void Scale2() 
        {
            Scale(2);
        }
    }
}
