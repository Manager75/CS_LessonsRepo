using System;

namespace CS_2_Lesson1
{
    public class Animals
    {
        public virtual string DisplayFirstWay()
        {
            return $"I am a {nameof(Animals)} class method";
        }

        public virtual string DisplaySecondWay()
        {
            return $"I am a {nameof(Animals)} class method";
        }

        public virtual string DisplayThirdWay()
        {
            return $"I am a {nameof(Animals)} class method";
        }
    }

    public class Cat : Animals
    {
        public override string DisplaySecondWay()
        {
            return $"I am a {nameof(Cat)} class method";
        }

        public new string DisplayThirdWay()
        {
            return $"I am a {nameof(Cat)} class method";
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        Animals animals = new Animals(); // все методы используются из базового класса Animals
    //        Console.WriteLine(animals.DisplayFirstWay());
    //        Console.WriteLine(animals.DisplaySecondWay());
    //        Console.WriteLine(animals.DisplayThirdWay());

    //        Animals animals1 = new Cat();
    //        Console.WriteLine(animals1.DisplayFirstWay()); // base - Animals
    //        Console.WriteLine(animals1.DisplaySecondWay()); // ovveride - Cat
    //        Console.WriteLine(animals1.DisplayThirdWay()); // base - Animals, потому что тип переменной Animals

    //        Cat animals2 = new Cat();
    //        Console.WriteLine(animals2.DisplayFirstWay()); // base - Animals
    //        Console.WriteLine(animals2.DisplaySecondWay()); // ovveride - Cat 
    //        Console.WriteLine(animals2.DisplayThirdWay()); // new - Cat

    //        Console.ReadKey();
    //    }
    //}
}
