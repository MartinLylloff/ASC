using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MandatoryAssignmentLibrary.Weapons
{
    public class Staff : AttackItem
    {
        public Staff(int damage, string name) : base(damage, 150, name, 50) { }

        public override void WeaponDamage()
        {
            if (!_hasUsedBuff)
            {
                Damage += 15;
            }
        }
    }
}
