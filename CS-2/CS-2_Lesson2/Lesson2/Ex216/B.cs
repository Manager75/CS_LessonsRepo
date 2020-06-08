using System.Collections;
using System.ComponentModel;



namespace Ex216
{

    // https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.ienumerator?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DRU-RU%26k%3Dk(System.Collections.IEnumerator);k(SolutionItemsProject);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1);k(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.7.2
    // https://ru.wikipedia.org/wiki/%D0%98%D1%82%D0%B5%D1%80%D0%B0%D1%82%D0%BE%D1%80_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    class B : IEnumerator
    {
        int[] arr;
        private int index;

        public B(params int[] Col)
        {
           arr = new int[Col.Length];

            for (int i = 0; i < Col.Length; i++)
            {
                arr[i] = Col[i];
            }
        }

        public object Current { get { return arr[index]; } }

        public bool MoveNext()
        {
            index++;
            return index < arr.Length;
        }

        public void Reset() { index = -1; }
    }
}
