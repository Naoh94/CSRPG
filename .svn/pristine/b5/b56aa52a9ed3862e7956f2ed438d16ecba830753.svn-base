using Engine.Command;
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
    public class InventarViewModel : IDialogRequestClose
    {
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public Player CurrentPlayer { get; set; }

        public ICommand CommandOk { get; private set; }

        public InventarViewModel(Player currentPlayer)
        {

            CurrentPlayer = currentPlayer;

            CommandOk = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)), null);
        }
    }
}
