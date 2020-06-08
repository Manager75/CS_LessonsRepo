
using SaverLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex212
{
    class Program
    {
        static void Main(string[] args)
        {
            var saverTxt = new SaverTxt("SaverFileName");
            var saverXml = new SaverXml("SaverXmlName");
            var saverJson = new SaverJson("SaverJsonName");

            Console.ReadLine();

            SaverFiles saver = new SaverFiles(saverTxt);

            saver.SaveAs();

            Console.ReadLine();

            saver.Logic = saverXml;
            saver.SetLogic(saverXml, "qwert");
            saver.SaveAs();

            Console.ReadLine();

            saver.SetLogic(saverJson, "1", "1");
            saver.SaveAs();

            Console.ReadLine();
        }
    }
}
