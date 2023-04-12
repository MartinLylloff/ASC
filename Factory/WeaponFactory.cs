using MandatoryAssignmentLibrary.Interfaces;
using MandatoryAssignmentLibrary.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignmentLibrary.Factory
{
    public class WeaponFactory
    {
        public static IAttackItem Create(WeaponType type, int damage, string name)
        {
            switch (type)
            {
                case WeaponType.Melee:
                    return new Sword(damage, name);
                case WeaponType.Ranged:
                    return new Bow(damage, name);
                case WeaponType.Magic:
                    return new Staff(damage, name);
                default:
                    return null;
            }

        }
    }
}
