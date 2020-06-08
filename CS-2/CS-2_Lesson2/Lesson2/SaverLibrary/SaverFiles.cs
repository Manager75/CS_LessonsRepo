using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaverLibrary
{
    public class SaverFiles
    {
        public ISaver Logic { get; set; }

        public void SetLogic(ISaver saver, string login, string password)
        {
            if (login == "1" && password == "1")
            {
                Logic = saver;
            }
        }

        public void SetLogic(ISaver saver, string promo)
        {
            if (promo=="qwert")
            {
                Logic = saver;
            }
        }

        public string Data { get; set; }

        public SaverFiles(ISaver Logic)
        {
            this.Logic = Logic;
        }

        private void GetData()
        {
            this.Data = Guid.NewGuid().ToString();
        }

        public void SaveAs()
        {
            this.GetData();
            Logic.SaveAs(Data);
        }
    }
}
