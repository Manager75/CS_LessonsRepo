using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex210
{
    class HeroAgillity: HeroBase
    {
        private int energy;
        private int maxEnergy;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Имя героя</param>
        /// <param name="Hp">Максимальное количество здоровья</param>
        /// <param name="Energy">Максимальное количество маны</param>
        public HeroAgillity(string Name, int Hp, int Energy):base(Name, Hp)
        {
            this.energy = Energy;
            this.maxEnergy = Energy;
            this.BattleCry();
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HeroAgillity() :
            this($"Hero #{++HeroBase.number}",
                HeroBase.r.Next(100, 200),
                HeroBase.r.Next(50, 150)
                )
        {
            
        }

        /// <summary>
        /// Метод, описывающий инфрмацию о герое
        /// </summary>
        /// <returns>Состояние объекта</returns>
        public override string GetInfo()
        {
            return base.GetInfo() + $" Energy: {this.energy}";
        }

        /// <summary>
        /// Метод, описывающий атаку
        /// </summary>
        /// <returns></returns>
        public void Attack(HeroBase hero)
        {
            hero.GetDamage(HeroStrength.r.Next(10, 20));
        }

      

        public override void BattleCry()
        {
            Console.WriteLine("буууууууу");
        }
    }
}
