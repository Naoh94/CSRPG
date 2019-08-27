using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Engine.Command;
using Engine.Interfaces;
using Engine.Models;
using Engine.Views;

namespace Engine.ViewModels
{
    public class GameSessionViewModel
    {
        private readonly IDialogService dialogService;

        #region "public propertys"
        public Player CurrentPlayer { get; set; }
        public World CurrentWorld { get; set; }

        public ICommand CommandAddExp { get; private set; }
        public ICommand CommandMoveNorth { get; private set; }
        public ICommand CommandMoveWest { get; private set; }
        public ICommand CommandMoveEast { get; private set; }
        public ICommand CommandMoveSouth { get; private set; }
        public ICommand CommandShowInfo { get; private set; }
        public ICommand CommandShowWorldMap { get; private set; }
        #endregion

        public GameSessionViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            CurrentWorld = WorldFactory.CreateWorld();

            // initialise new Player
            CurrentPlayer = new Player
            {
                Name = "Naoh",
                CharacterClass = "Mage",
                HitPoints = 100,
                Gold = 10,
                ExperiencePoints = 0,
                Level = 1,
                CurrentLocation = CurrentWorld.LocationAt(1, -1)
            };

            // initialise Commands                                           
            CommandAddExp = new RelayCommand(AddExpExecute, AddExpCanExecute);
            CommandMoveNorth = new RelayCommand(MoveNorthExecute, MoveNorthCanExecute);
            CommandMoveWest = new RelayCommand(MoveWestExecute, MoveWestCanExecute);
            CommandMoveEast = new RelayCommand(MoveEastExecute, MoveEastCanExecute);
            CommandMoveSouth = new RelayCommand(MoveSouthExecute, MoveSouthCanExecute);
            CommandShowInfo = new RelayCommand(ShowInfoExecute, null);
            CommandShowWorldMap = new RelayCommand(ShowWorldMapExecute, null);
        }

        #region "Methods for Commands"
        private void AddExpExecute(object obj)
        {
            CurrentPlayer.ExperiencePoints += 10;
        }

        private bool AddExpCanExecute(object obj)
        {
            return CurrentPlayer.ExperiencePoints + 10 <= 100;
        }

        private void MoveNorthExecute(object obj)
        {
            CurrentPlayer.CurrentLocation = CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate, CurrentPlayer.CurrentLocation.YCoordinate + 1);
        }

        private void MoveWestExecute(object obj)
        {
            CurrentPlayer.CurrentLocation = CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate - 1, CurrentPlayer.CurrentLocation.YCoordinate);
        }

        private void MoveEastExecute(object obj)
        {
            Location cPlayerLoc = CurrentPlayer.CurrentLocation;

            CurrentPlayer.CurrentLocation = CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate + 1, CurrentPlayer.CurrentLocation.YCoordinate);
        }

        private void MoveSouthExecute(object obj)
        {
            Location cPlayerLoc = CurrentPlayer.CurrentLocation;

            CurrentPlayer.CurrentLocation = CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate, CurrentPlayer.CurrentLocation.YCoordinate - 1);
        }

        private bool MoveNorthCanExecute(object obj)
        {
            return CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate, CurrentPlayer.CurrentLocation.YCoordinate + 1) != null;
        }

        private bool MoveWestCanExecute(object obj)
        {
            return CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate - 1, CurrentPlayer.CurrentLocation.YCoordinate) != null;
        }

        private bool MoveEastCanExecute(object obj)
        {
            return CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate + 1, CurrentPlayer.CurrentLocation.YCoordinate) != null;
        }

        private bool MoveSouthCanExecute(object obj)
        {
            return CurrentWorld.LocationAt(CurrentPlayer.CurrentLocation.XCoordinate, CurrentPlayer.CurrentLocation.YCoordinate - 1) != null;
        }


        /// <summary>
        /// Open a new dialaog. Its decoupled from the ViewModel and View. Unit test is not going to show the dialog!
        /// </summary>
        /// <param name="obj"></param>
        private void ShowInfoExecute(object obj)
        {
            var viewModel = new PlayerInfoViewModel(CurrentPlayer);

            bool? result = dialogService.ShowDialog(viewModel);

            if (result.HasValue)
            {
                if (result.Value)
                {
                    // Ok
                }
                else
                {
                    // Cancelled
                }
            }

        }

        private void ShowWorldMapExecute(object obj)
        {
            var viewModel = new WorldMapViewModel();

            bool? result = dialogService.ShowDialog(viewModel);

            if (result.HasValue)
            {
                if (result.Value)
                {
                    // Ok
                }
                else
                {
                    // Cancelled
                }
            }

        }
        #endregion
    }
}