using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignmentLibrary.Interfaces;

namespace MandatoryAssignmentLibrary
{
    public class DefenceItem : Item, IDefenceItem
    {
        public int DefenceValue { get; set; }

        public DefenceItem(string name, int defenceValue) : base(name)
        {
            DefenceValue = defenceValue;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
