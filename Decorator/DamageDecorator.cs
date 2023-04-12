using MandatoryAssignmentLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignmentLibrary.Decorator
{
    internal class DamageDecorator : IAttackItem
    {
        private IAttackItem _attackItem;
        public int Damage { get; set; }
        public int Range { get; set; }

        public string Name { get; set; }

        public DamageDecorator(IAttackItem item)
        {
            _attackItem = item;
            Damage = _attackItem.Damage;
            Range = _attackItem.Range;

            Name = _attackItem.Name;

        }

        public void Buff()
        {
            _attackItem.Damage *= 2;
        }

    }
}
