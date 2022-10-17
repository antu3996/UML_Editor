using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Class_Method
    {
        public string MethodName { get; set; }
        public List<Method_Parameter> Parameters { get; set; } = new List<Method_Parameter>();
        public string ReturnType { get; set; }
        public string Modifier { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            if(this.Modifier == "private")
            {
                sb.Append("-");
            }
            if(this.Modifier == "public")
            {
                sb.Append("+");
            }
            if (this.Modifier == "protected")
            {
                sb.Append("#");
            }
            sb.Append($"{this.MethodName}({this.GetParametersString()}): {this.ReturnType}");
            
            return sb.ToString();
        }

        private string GetParametersString()
        {
            if (this.Parameters.Count > 0)
            {
                StringBuilder newSb = new StringBuilder("");
                foreach (Method_Parameter item in this.Parameters)
                {
                    newSb.Append($"{item.ParameterName}: {item.DataType}, ");
                }
                newSb.Remove(newSb.Length - 2, 2);

                return newSb.ToString();
            }
            return "";
        }

        private bool IsSameAs(Class_Method other)
        {
            if (this.MethodName != other.MethodName)
            {
                return false;
            }
            
            if (this.Parameters.Count == other.Parameters.Count)
            {
                for (int i = 0; i < this.Parameters.Count; i++)
                {
                    if (this.Parameters[i].DataType != other.Parameters[i].DataType)
                    {
                        return false;
                    }       
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
