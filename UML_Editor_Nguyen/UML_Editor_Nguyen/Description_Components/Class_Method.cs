using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Class_Method
    {
        public string MethodName { get; set; }
        public List<Method_Parameter> Parameters { get; set; } = new List<Method_Parameter>();
        public DataType ReturnType { get; set; }
        public string Modifier { get; set; }
        public bool IsVoid { get; set; }

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
            string rtrnType = this.IsVoid ? "void" : this.ReturnType.Name;
            sb.Append($"{this.MethodName}({this.GetParametersString()}): {rtrnType}");
            
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

        public void ImportData(Class_Method other)
        {
            this.MethodName = other.MethodName;
            for (int i = 0; i < other.Parameters.Count; i++)
            {
                Method_Parameter newPara = new Method_Parameter();
                newPara.ImportData(other.Parameters[i]);
                this.Parameters.Add(newPara);
            }
            this.ReturnType = other.ReturnType;
            this.Modifier = other.Modifier;
            this.IsVoid = other.IsVoid;
    }
    }
}
