﻿using Engine.Command;
using Engine.DialogService;
using Engine.Interfaces;
using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Engine.ViewModels
{
    public class PlayerInfoViewModel : IDialogRequestClose
    {
        public Player CurrentPlayer { get; set; }

        public ICommand CommandOk { get; private set; }
        public ICommand CommandCancel { get; private set; }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public PlayerInfoViewModel (Player currentPlayer)
        {
            CurrentPlayer = currentPlayer;

            CommandOk = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)), null);
            CommandCancel = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), null);
            //CommandCancel = new RelayCommand(CancelExecute, null);
        }

        private void OkExecute(object obj)
        {
          
        }

        private void CancelExecute(object obj)
        {
        
        }
    }
}
