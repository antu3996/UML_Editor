using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Method_Parameter
    {
        public string ParameterName { get; set; }
        public string DataType { get; set; }

        public override string ToString()
        {
            return $"{this.ParameterName}: {this.DataType}";
        }
    }
}
