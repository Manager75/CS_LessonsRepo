using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex215
{
    public  class MyException : Exception
    {
        

        string msg;

        public override string Message => this.msg;

        public int Error { get; set; }

        public MyException(string Msg, int Error)  //:base(Msg)
        {
            this.Error = Error;
            this.msg = Msg;
        }

        public override string ToString()
        {
            return $"{this.Error} {base.Message}";
            
        }
    }
}
