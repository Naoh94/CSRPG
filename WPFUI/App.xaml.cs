﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Engine.DialogService;
using Engine.Interfaces;
using Engine.ViewModels;
using Engine.Views;


namespace WPFUI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(MainWindow);

            dialogService.Register<PlayerInfoViewModel, PlayerInfoView>();
            dialogService.Register<WorldMapViewModel, WorldMapView>();

            var viewModel = new GameSessionViewModel(dialogService);
            var view = new MainWindow { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}
