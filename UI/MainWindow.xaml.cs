using System;
using System.IO.Abstractions;
using System.Reflection;
using System.Windows;

using SpecLogLogoReplacer.UI.ViewModel;

namespace SpecLogLogoReplacer.UI
{
  public partial class MainWindow
  {
    private readonly SettingsManager settingsManager;

    private readonly FileSystem fileSystem;

    public MainWindow()
    {
      this.fileSystem = new FileSystem();
      this.settingsManager = new SettingsManager(fileSystem);

      InitializeComponent();
    }

    private MainViewModel ViewModel
    {
      get
      {
        return (MainViewModel)DataContext;
      }
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
      var pathToSettingsFile = DeterminePathToSettingsFile();

      var settings = this.fileSystem.File.Exists(pathToSettingsFile) ? this.settingsManager.LoadSettings(pathToSettingsFile) : new Settings();

      this.ViewModel.SetSettings(settings);
    }

    private string DeterminePathToSettingsFile()
    {
      var pathToSettingsFile =
        this.fileSystem.Path.Combine(
          this.fileSystem.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
          "settings.xml");
      return pathToSettingsFile;
    }

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
      var pathToSettingsFile = DeterminePathToSettingsFile();

      var settings = this.ViewModel.GetSettings();

      this.settingsManager.SaveSettings(pathToSettingsFile, settings);
    }
  }
}
