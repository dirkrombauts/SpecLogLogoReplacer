using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Abstractions;
using System.Windows;

using SpecLogLogoReplacer.UI.ViewModel;

namespace SpecLogLogoReplacer.UI
{
  public partial class MainWindow
  {
    private readonly IFileSystem fileSystem;

    public MainWindow()
    {
      InitializeComponent();

      this.fileSystem = new FileSystem();
    }

    private MainViewModel ViewModel
    {
      get
      {
        return (MainViewModel)DataContext;
      }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      var pathToSpecLogFile = this.ViewModel.PathToSpecLogFile;
      var pathToNewLogo = this.newLogoPath.Text;

      var specLogFile = this.fileSystem.File.ReadAllText(pathToSpecLogFile);

      Image newLogo;

      using (var stream = this.fileSystem.File.OpenRead(pathToNewLogo))
      {
        newLogo = Image.FromStream(stream);
      }

      var patchedSpecLogFile = new LogoReplacer().Replace(specLogFile, newLogo, ImageFormat.Png);

      this.fileSystem.File.WriteAllText(pathToSpecLogFile, patchedSpecLogFile);
    }
  }
}
