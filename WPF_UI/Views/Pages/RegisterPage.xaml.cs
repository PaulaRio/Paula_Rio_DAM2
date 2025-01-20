// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Wpf.Ui.Abstractions.Controls;

namespace Wpf.Ui.Demo.Mvvm.Views.Pages;

/// <summary>
/// Interaction logic for DataView.xaml
/// </summary>
public partial class RegisterPage : INavigableView<ViewModels.RegisterViewModel>
{
    public ViewModels.RegisterViewModel ViewModel { get; }

    public RegisterPage(ViewModels.RegisterViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();
        Loaded += Page_Loaded;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        this.ViewModel.OnNavigatedFromAsync();
    }
}
