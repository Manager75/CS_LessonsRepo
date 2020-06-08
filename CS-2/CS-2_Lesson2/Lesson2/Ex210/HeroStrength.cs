using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex210
{

    interface IInterface
    {
        void A();
        int B();

        int MyProperty123 { get; set; }
    }

    class HeroStrength: HeroBase 
    {
        private int rage;
        private int maxRage;
        private int casting;

       
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Имя героя</param>
        /// <param name="Hp">Максимальное количество здоровья</param>
        /// <param name="Rage">Максимальное количество маны</param>
        public HeroStrength(string Name, int Hp, int Rage) : base(Name, Hp)
        {
            this.rage = Rage;
            this.maxRage = Rage;
            this.casting = 10;
            this.BattleCry();
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HeroStrength() :
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
            return base.GetInfo() + $" Rage: {this.rage}";
        }

        /// <summary>
        /// Метод, описывающий атаку
        /// </summary>
        /// <returns></returns>
        public void Attack(HeroBase hero)
        {
            if (this.rage - casting >= 0)
            {
                this.rage -= casting;
                hero.GetDamage(HeroStrength.r.Next(10, 20));
            }
        }


        public override void BattleCry()
        {
            Console.WriteLine("Вооооууу");
        }

    }
}
