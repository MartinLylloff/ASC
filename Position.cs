using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryAssignmentLibrary
{
    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Position(int posX, int posY)
        {
            XmlDocument configDoc = new XmlDocument();
            string _path = Environment.GetEnvironmentVariable("GameFrameworkConfig");
            configDoc.Load(_path);
            var world = configDoc.DocumentElement.SelectSingleNode("Playground");
            int maxX = Convert.ToInt32(world.SelectSingleNode("MaxX").InnerText);
            int maxY = Convert.ToInt32(world.SelectSingleNode("MaxY").InnerText);


            PosX = posX > maxX ? maxX : posX;
            PosY = posY > maxY ? maxY : posY;
                //theRandom.Next(0, World.Instance().MaxY+1);
        }

        public override string ToString()
        {
            return $"X: {PosX}, Y: {PosY}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   PosX == position.PosX &&
                   PosY == position.PosY;
        }
    }
}
