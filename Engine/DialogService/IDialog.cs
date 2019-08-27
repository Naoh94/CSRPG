using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Engine.Interfaces
{
    // provides support to displaying the windows
    public interface IDialog
    {
        /// <summary>
        /// these are the basic accessories for the dialog in mvvm pattern 
        /// </summary>
        object DataContext { get; set; }        // To set up the value
        bool? DialogResult { get; set; }        // extrach result
        Window Owner { get; set; }              // define the owning window for this. When show dialog the main application is the window who use that
        void Close();                           // to close the window?
        bool? ShowDialog();                     // ability to show the window
    }
}
