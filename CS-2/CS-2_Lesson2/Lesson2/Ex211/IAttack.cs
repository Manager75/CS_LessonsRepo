using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex210
{
 
    /// <summary>
    /// Интерфейс описывающий атаку
    /// </summary>
    interface IAttack
    {
        /// <summary>
        /// Метод атаки
        /// </summary>
        /// <param name="hero">Кого бить</param>
        void Attack(HeroBase hero);
    }
}
