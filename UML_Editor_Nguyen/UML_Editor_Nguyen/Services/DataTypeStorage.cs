using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Services
{
    public sealed class DataTypeStorage
    {
        private static readonly DataTypeStorage instance = new DataTypeStorage();
        static DataTypeStorage() {}

        private DataTypeStorage() 
        {
        }

        public static DataTypeStorage Instance
        {
            get
            {
                return instance;
            }
        }

        public List<DataType> currentData { get; set; } = new List<DataType>();


        public void LoadDefault()
        {
            this.currentData.Add(new DataType() { Name = "Boolean", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Byte", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "SByte", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Char", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Decimal", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Double", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Single", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Int32", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "UInt32", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "IntPtr", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "UIntPtr", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Int64", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "UInt64", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Int16", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "UInt16", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "String", Namespace = "System" });
            this.currentData.Add(new DataType() { Name = "Object", Namespace = "System" });
        }


        public void LoadData(List<DataType> data)
        {
            if (data != null)
            {
                this.currentData = data;
            }
        }
        public List<DataType> GetData()
        {
            return this.currentData;
        }
    }
}
