using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex210
{

    class HeroIntelligence : HeroBase, IHealing
    {
        private int mp;
        private int maxMp;
        private int casting;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Имя героя</param>
        /// <param name="Hp">Максимальное количество здоровья</param>
        /// <param name="Mp">Максимальное количество маны</param>
        public HeroIntelligence(string Name, int Hp, int Mp) : base(Name, Hp)
        {
            this.mp = Mp;
            this.maxMp = Mp;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HeroIntelligence() :
            this($"Hero #{++HeroBase.number}",
                HeroBase.r.Next(100, 200),
                HeroBase.r.Next(50, 150)
                )
        {

        }

        /// <summary>
        /// Метод, описывающий лечение
        /// </summary>
        /// <returns></returns>
        public void Healing(HeroBase hero)
        {
            if (this.mp - casting >= 0)
            {
                this.mp -= casting;
                hero.ToBeHealed(HeroStrength.r.Next(10, 20));
            }
        }



        /// <summary>
        /// Метод, описывающий инфрмацию о герое
        /// </summary>
        /// <returns>Состояние объекта</returns>
        public override string GetInfo()
        {
            return base.GetInfo() + $" Mp: {this.mp}";
        }
    }
}