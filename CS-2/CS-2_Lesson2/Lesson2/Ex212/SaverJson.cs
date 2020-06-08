namespace Ex212
{
    class SaverJson : SaverLibrary.ISaver
    {
        private string fileName;
        public SaverJson(string FileName)
        {
            this.fileName = FileName;
        }

        private string SerJson(string Data)
        {
            return Data;
        }

        public void SaveAs(string Data)
        {
            ///// Сериализация в json
            string json = SerJson(Data);
            System.IO.File.WriteAllText($"_{fileName}.json", json);
        }
    }
}
