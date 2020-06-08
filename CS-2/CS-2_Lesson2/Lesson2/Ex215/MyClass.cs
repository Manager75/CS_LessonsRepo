using System;
using System.IO;
using System.Threading;

namespace Ex215
{
 
    public class MyClass :ICloneable
    {
       

        public static void A()
        {
            



            #region MyExceptions

            throw new MyException("msg12345", 12345);
            throw new MyException("msg1234", 1234);
            throw new MyException("msg123", 123);
            throw new MyException("msg12", 12);
            throw new MyException("msg1", 1);

            #endregion

            throw new MemberAccessException();
            throw new DivideByZeroException();
            throw new FileNotFoundException();
           
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
