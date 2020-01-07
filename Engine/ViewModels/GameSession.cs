
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification
    {
        private Location _currentLocation;
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToSouth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
            }
        }

        public bool HasLocationToNorth
        {
            get
            {
                return CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            }


        }

        public bool HasLocationToSouth
        {
            get
            {
                return CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        public bool HasLocationToEast
        {
            get
            {
                return CurrentWorld.locationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool HasLocationToWest
        {
            get
            {
                return CurrentWorld.locationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public GameSession()
        {
            CurrentPlayer = new Player 
            {
                Name = "Bob the Jittery",
                CharacterClass = "Berserker",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1
        };

            
            
            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.locationAt(0, 0 );

        }

        public void MoveNorth()
        {
            if(HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
            
        }

        public void MoveEast()

        { 
            if(HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
            
        }

        public void MoveSouth()
        {
            if(HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        public void MoveWest()
        {
            if(HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }


    }
}