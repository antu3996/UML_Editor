using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Comparers
{
    public class UML_ClassRect_Comparer : IComparer<UML_ClassRect>
    {
        public int Compare(UML_ClassRect? x, UML_ClassRect? y)
        {
            return x!.Layer_Index.CompareTo(y!.Layer_Index);
        }
    }
}
