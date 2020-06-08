using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex213
{
    class Storage
    {
        List<Worker> list;

        public List<Worker> ListWorker { get => this.list; }

        public Storage(params Worker[] Args)
        {
            list = new List<Worker>();
            foreach (var e in Args)
            {
                list.Add(e);
            }
        }

        public Storage() : this(new Worker[0])
        {
            this.list = new List<Worker>{
                new Worker("имя_1", 11, 111),
                new Worker("имя_2", 22, 333),
                new Worker("имя_3", 55, 222),
                new Worker("имя_4", 44, 555),
                new Worker("имя_5", 11, 333)
            };
        }
    }
}
