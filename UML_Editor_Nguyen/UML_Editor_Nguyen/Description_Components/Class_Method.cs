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
        public string Parameters { get; set; }
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
            sb.Append($"{this.MethodName}({this.Parameters}): {this.ReturnType}");
            
            return sb.ToString();
        }
    }
}
