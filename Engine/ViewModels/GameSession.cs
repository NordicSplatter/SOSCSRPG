
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
    public class GameSession : INotifyPropertyChanged
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
                OnPropertyChanged("CurrentLocation");
                OnPropertyChanged("HasLocationToNorth");
                OnPropertyChanged("HasLocationToSouth");
                OnPropertyChanged("HasLocationToEast");
                OnPropertyChanged("HasLocationToWest");
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
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Bob the Jittery";
            CurrentPlayer.CharacterClass = "Berserker";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            
            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.locationAt(0, 0 );

        }

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.locationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}