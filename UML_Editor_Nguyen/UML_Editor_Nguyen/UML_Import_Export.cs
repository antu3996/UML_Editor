using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen
{
    public static class UML_Import_Export
    {
        public static UML_Objects_Wrapper ImportFromFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                UML_Objects_Wrapper loaded = JsonSerializer.Deserialize<UML_Objects_Wrapper>(json);
                return loaded;

            }
            else
            {
                return null;
            }
        }
        public static void ExportToFile(UML_Objects_Wrapper data, string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            string json = JsonSerializer.Serialize(data);

            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.Write(json);

                writer.Close();
            }
        }
        public static void ExportToPicture()
        {

        }
    }
}
