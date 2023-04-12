using MandatoryAssignmentLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryAssignmentLibrary
{
    /// <summary>
    /// Class used to create a creature.
    /// </summary>
    public class Creature
    {
        private Random _rand { get; set; } = new Random();
        public int Hitpoints { get; set; }
        public string Name { get; set; }
        public List<IAttackItem> AttackItems { get; set; } = new List<IAttackItem>();
        public List<IDefenceItem> DefenceItems { get; set; } = new List<IDefenceItem>();
        public Position Position { get; set; }
        public bool IsAlive { get; set; } = true;

        public Creature()
        {
            XmlDocument configDoc = new XmlDocument();
            string _path = Environment.GetEnvironmentVariable("GameFrameworkConfig");
            configDoc.Load(_path);
            var world = configDoc.DocumentElement.SelectSingleNode("Playground");
            int maxX = Convert.ToInt32(world.SelectSingleNode("MaxX").InnerText);
            int maxY = Convert.ToInt32(world.SelectSingleNode("MaxY").InnerText);
            Position = new Position(_rand.Next(0, maxX), _rand.Next(0, maxY));
        }

        public int Damage 
        { 
            get { return AttackItems.Sum(dmg => dmg.Damage); }
        }

        public int Hit()
        {
            return _rand.Next(Damage, Damage - 5);
        }

        public void Loot(IItem item)
        {
            switch (item.GetType())
            { 
                case (IAttackItem):
                    AttackItems.Add((AttackItem)item);
                    break;
                case (IDefenceItem):
                    DefenceItems.Add((DefenceItem)item);
                    break;
            }
        }

        public int ReceiveHit(int damage)
        {
            if(damage > 0 && IsAlive)
            {
                Hitpoints -= damage;
                if(Hitpoints <= 0) 
                {
                    IsAlive = false;
                }
            }
            return Hitpoints;

        }

        public void RerollPosition(int maxX, int maxY)
        {
            Position = new Position(_rand.Next(0, maxX), _rand.Next(0, maxY));
        }

    }
}
