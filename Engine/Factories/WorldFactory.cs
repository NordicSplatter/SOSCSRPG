using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;


namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, -1, "Home",
                "This is your house!",
                "/Engine;component/Images/Locations/romanHouse.png");

            newWorld.AddLocation(0, 0, "Town Center",
                "The center of your beloved city!",
                "/Engine;component/Images/Locations/townSquare.png");

            newWorld.AddLocation(-1, -1, "Tavern",
                "Ah the tavern, gossip, wine and good music!",
                "/Engine;component/Images/Locations/tavern.png");

            newWorld.AddLocation(-2, -1, "Tavern's Basement",
                "The basement smells of mold, cheese, and wine",
                "/Engine;component/Images/Locations/TavernBasement.png");

            newWorld.AddLocation(-1, 0, "Market",
                "The market, traders love to peddle their wares!",
                "/Engine;component/Images/Locations/marketPlace.png");

            newWorld.AddLocation(1, 0, "The Town Gate",
                "This sturdy gate has kept many would-be enemies at bay!",
                "/Engine;component/Images/Locations/townGate.png");

            newWorld.AddLocation(2, 0, "Wildlands",
                "The wildlands, where bandits, monsters, and other evils roam..",
                "/Engine;component/Images/Locations/wilderness.png");

            newWorld.AddLocation(0, 1, "Garrison",
                "Ah the glorious sight of our brave soldiers....or are they oppressors..",
                "/Engine;component/Images/Locations/barrack.png");

            newWorld.AddLocation(0, 2, "Colosseum",
                "Nothing more exciting than the stench of iron and blood!",
                "/Engine;component/Images/Locations/colosseum.png");

            return (newWorld);
        }
    }
}
