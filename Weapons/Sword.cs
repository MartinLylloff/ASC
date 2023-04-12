using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignmentLibrary.Weapons
{
    public class Sword : AttackItem
    {
        public Sword(int damage, string name) : base(damage, 60, name, 150) { }

        public override void WeaponDamage()
        {
            if (!_hasUsedBuff)
            {
                Damage += 20;
            }
        }
    }
}
