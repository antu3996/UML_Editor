using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;

namespace UML_Editor_Nguyen.Description_Components
{
    public class BindingCircle : Circle
    {
        public BindingCircle( int x, int y, int radius = 10) : base(x, y, radius)
        {
        }
    }
}
