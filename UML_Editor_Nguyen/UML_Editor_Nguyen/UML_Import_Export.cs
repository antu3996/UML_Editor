using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_Editor_Nguyen
{
    public static class UML_Import_Export
    {
        public static UML_Objects_Wrapper ImportFromFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);

                JsonSerializer newDeserializer = new JsonSerializer();
                newDeserializer.PreserveReferencesHandling = PreserveReferencesHandling.All;

                UML_Objects_Wrapper loaded = null;

                using (StreamReader reader = new StreamReader(filepath))
                using (JsonReader jsonReader = new JsonTextReader(reader))
                {
                    loaded = newDeserializer.Deserialize<UML_Objects_Wrapper>(jsonReader);

                }
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



            using (StreamWriter writer = new StreamWriter(filepath))
            using(JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.PreserveReferencesHandling = PreserveReferencesHandling.All;

                jsonSerializer.Serialize(jsonWriter, data);

                writer.Close();
            }
        }
        public static void ExportToPicture(PictureBox pictureBox, UML_Editor_Engine mainEngine, string filepath)
        {

            Bitmap pic = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(pic))
            {
                g.FillRectangle(Brushes.White, 0, 0, pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
                mainEngine.Draw(g);
                pic.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        
    }
}
