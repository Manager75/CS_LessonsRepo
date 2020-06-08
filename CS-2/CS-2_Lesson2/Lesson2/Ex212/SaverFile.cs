using SaverLibrary;

namespace Ex212
{
    class SaverTxt : SaverLibrary.ISaver
    {
        private string fileName;

        public SaverTxt(string FileName)
        {
            this.fileName = FileName;
        }
        public void SaveAs(string Data)
        {
            System.IO.File.WriteAllText($"_{fileName}.txt", Data);
        }
    }
}
