using MandatoryAssignmentLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignmentLibrary.Weapons
{
    public class Bow : AttackItem
    {
        public Bow(int damage, string name) : base(damage, 100, name, 100) 
        {
        }

        public override void WeaponDamage()
        {
            if (!_hasUsedBuff)
            {
                Damage += 25;
            }
        }
    }
}
