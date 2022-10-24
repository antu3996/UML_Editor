using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Services
{
    public class DataType
    {
        public string Namespace { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
