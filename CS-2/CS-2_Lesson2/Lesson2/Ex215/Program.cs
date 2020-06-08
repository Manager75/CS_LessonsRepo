using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Ex215
{
     

    class Program
    {

        static void Main(string[] args)
        {
           

            try
            {
                MyClass.A();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка DivideByZeroException");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка FileNotFoundException");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка IndexOutOfRangeException {e.Message}");
            }
            // ========================
            catch (MyException e) when (e.Error == 1 && DateTime.Now.Day == 1)
            {
                Console.WriteLine("Ошибка MyException 1");
                Console.WriteLine(e.Message);
            }
            catch (MyException e) when (e.Error == 1 && DateTime.Now.Day == 2)
            {
                Console.WriteLine("Ошибка MyException 2025");
                Console.WriteLine(e.Message);
            }
            catch (MyException e) when (e.Error == 2)
            {
                Console.WriteLine("Ошибка MyException 2");
                Console.WriteLine(e.Message);
            }
            catch (MyException e) when (e.Error == 4)
            {
                Console.WriteLine("Ошибка MyException 2");
                Console.WriteLine(e.Message);
            }
            catch (MyException e) when (e.Error == 1234)
            {
                Console.WriteLine("Ошибка MyException 2");
                Console.WriteLine(e.Message);
            }
            catch (MyException e) when (e.Error == 313)
            {
                Console.WriteLine("Ошибка MyException 2");
                Console.WriteLine(e.Message);
            }
            //========
            catch (Exception e)
            {
                Console.WriteLine("Ошибка Exception");
                Console.WriteLine(e.GetType());
            }
            finally   // Блок завершения
            {
                Console.WriteLine("finally");
            }
        }
    }
}