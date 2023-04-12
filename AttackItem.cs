using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignmentLibrary.Interfaces;

namespace MandatoryAssignmentLibrary
{
    public abstract class AttackItem : IAttackItem
    {
        protected bool _hasUsedBuff = false;
        public int Damage { get; set; }
        public int Range { get; set; }
        public int CurrentDurability { get; }
        public string Name { get; set; }
        public int MaximumDurability { get; set; }
        

        protected AttackItem(int damage, int range, string name, int maximumDurability)
        {
            Damage = damage;
            Range = range;
            Name = name;
            CurrentDurability = maximumDurability;
            MaximumDurability = maximumDurability;
        }

        public AttackItem()
        {
        }

        public override string? ToString()
        {
            return base.ToString();
        }

 


        public abstract void WeaponDamage();

        public void Buff()
        {
            throw new NotImplementedException();
        }

    }
}
