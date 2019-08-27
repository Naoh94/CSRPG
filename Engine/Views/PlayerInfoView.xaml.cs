using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Engine.Views
{
    /// <summary>
    /// Interaktionslogik für PlayerInfoView.xaml
    /// </summary>
    public partial class PlayerInfoView : Window, IDialog
    {
        public PlayerInfoView()
        {
            InitializeComponent();
        }
    }
}
