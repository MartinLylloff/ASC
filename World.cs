using MandatoryAssignmentLibrary.Factory;
using MandatoryAssignmentLibrary.Interfaces;
using MandatoryAssignmentLibrary.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MandatoryAssignmentLibrary
{
    public class World
    {
        private readonly String horizontalLine = " ";
        private static World _instance;
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<Position> thePositions { get; set; } = new List<Position>();

        public List<Position> theListOfPositions { get; set; } = new List<Position>();



        // Defines the map size
        private World InitializeWorld()
        {

            IAttackItem first = WeaponFactory.Create(WeaponType.Melee, 100, "The first weapon");
            IAttackItem second = WeaponFactory.Create(WeaponType.Ranged, 85, "The second weapon");
            IAttackItem third = WeaponFactory.Create(WeaponType.Magic, 105, "The third weapon");

            IDefenceItem firstDefence = new DefenceItem("Skjoldet", 25);

            List<IAttackItem> attackItems = new List<IAttackItem>() { first, second, third };
            List<IDefenceItem> defenceItems = new List<IDefenceItem>() { firstDefence };

            XmlDocument configDoc = new XmlDocument();
            string _path = Environment.GetEnvironmentVariable("GameFrameworkConfig");
            configDoc.Load(_path);
            var world = configDoc.DocumentElement.SelectSingleNode("Playground");
            int maxX = Convert.ToInt32(world.SelectSingleNode("MaxX").InnerText);
            int maxY = Convert.ToInt32(world.SelectSingleNode("MaxY").InnerText);
            int amountOfCreatures = Convert.ToInt32(world.SelectSingleNode("AmountOfCreatures").InnerText);
            this.MaxX = maxX;
            this.MaxY = maxY;
            Creatures = new List<Creature>();
            for (int i = 0; i < amountOfCreatures; i++)
            {

                Creature theCreature = new Creature() { Name = "Creature" + i, AttackItems = attackItems, DefenceItems = defenceItems, Hitpoints = 100 + i };
                while (theListOfPositions.Contains(theCreature.Position))
                {
                    theCreature.RerollPosition(maxX, maxY);
                }
                Creatures.Add(theCreature);
                theListOfPositions.Add(theCreature.Position);
            }
            Console.WriteLine("The world has been created");
            return this;
        }



        public static World Instance()
        {
            return _instance ?? new World();
        }

        private World()
        {
            _instance = InitializeWorld();
            for (int i = 0; i < _instance.MaxX; i++)
            {
                horizontalLine += "-";
            }
            horizontalLine += " ";
        }

        public void PrintWorld()
        {
            Console.Clear();
            Console.WriteLine("Fight game: ");
            Console.WriteLine(horizontalLine);
            for (int r = 0; r < _instance.MaxY; r++)
            {
                Console.Write("|");
                PrintRow(r);
                Console.WriteLine($"|");
            }
            Console.WriteLine(horizontalLine);
            foreach (Creature creature in Creatures)
            {
                Console.WriteLine("Creature position X: " + creature.Position.PosX + " Position Y: " + creature.Position.PosY + "\n");
            }      

        }

        private void PrintRow(int r)
        {
            for (int c = 0; c < _instance.MaxX; c++)
            {
                PrintColRowChar(r, c);
            }
        }

        private void PrintColRowChar(int row, int col)
        {
            Position p = new Position(col, row);

            var positions = Creatures.Select(it => it.Position);

            bool isMatch = false;

            foreach (var position in positions)
            {
                if (position.Equals(p))
                {

                    isMatch = true;
                    break;
                }
            }

            if (isMatch)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('X');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(' ');
            }

        }
    }
}
