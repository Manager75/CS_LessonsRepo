using Ex213;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex214
{
    class StorageNew:IEnumerable
    {
        List<Worker> list;

        public List<Worker> ListWorker { get => this.list; }

        public StorageNew(params Worker[] Args)
        {
            list = new List<Worker>();
            foreach (var e in Args)
            {
                list.Add(e);
            }
        }

        public StorageNew() : this(new Worker[0])
        {
            this.list = new List<Worker>{
                new Worker("имя_1", 11, 111),
                new Worker("имя_2", 22, 333),
                new Worker("имя_3", 55, 222),
                new Worker("имя_4", 44, 555),
                new Worker("имя_5", 11, 333)
            };
        }
        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
            
        }
    }
}
