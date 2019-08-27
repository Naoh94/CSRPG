using Engine.Command;
using Engine.DialogService;
using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Engine.ViewModels
{
    public class WorldMapViewModel : IDialogRequestClose
    {
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public ICommand CommandOk { get; private set; }

        public WorldMapViewModel()
        {

            CommandOk = new RelayCommand(p => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)), null);
        }
    }
}
