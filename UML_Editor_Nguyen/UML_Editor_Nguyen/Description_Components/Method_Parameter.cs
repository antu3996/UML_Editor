using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Method_Parameter
    {
        public string ParameterName { get; set; }
        public DataType DataType { get; set; }

        public override string ToString()
        {
            return $"{this.ParameterName}: {this.DataType}";
        }

        public void ImportData(Method_Parameter other)
        {
            this.ParameterName = other.ParameterName;
            this.DataType = other.DataType;
        } 
    }
}
