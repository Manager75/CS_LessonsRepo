using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex210
{
    class Program
    {
        static void Main(string[] args)
        {

            HeroIntelligence hero = new HeroIntelligence();
 
            var target = new HeroAgillity();

            List<IAttack> attacks = new List<IAttack>()
            {
                new HeroAgillity(),
                new HeroAgillity(),
                new HeroAgillity(),
                new HeroAgillity(),
                new HeroStrength(),
                new HeroStrength(),
                new HeroStrength(),
            };

            foreach (var item in attacks)
            {
                
                item.Attack(target);

                Console.WriteLine(">>> "+(item as HeroBase).GetInfo());

                Console.WriteLine(target.GetInfo());
            }

        }
    }
}
