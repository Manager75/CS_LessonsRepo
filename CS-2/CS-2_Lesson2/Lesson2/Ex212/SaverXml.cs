using System.IO;

namespace Ex212
{
 
    class SaverXml : SaverLibrary.ISaver
    {
        private string fileName;
        public SaverXml(string FileName)
        {
            this.fileName = FileName;
        }

        private string SerXml(string Data)
        {
            return Data;
        }

        public void SaveAs(string Data)
        {
            ///// Сериализация в xml
            string xml = SerXml(Data);
            System.IO.File.WriteAllText($"_{fileName}.xml", xml);
        }
    }
}
