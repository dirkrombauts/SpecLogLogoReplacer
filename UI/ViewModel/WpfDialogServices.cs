using System;

using Ookii.Dialogs.Wpf;

namespace Aim.SpecLogLogoReplacer.UI.ViewModel
{
  public class WpfDialogServices : IDialogServices
  {
    public string BrowseForFile(string extension)
    {
      var vistaOpenFileDialog = new VistaOpenFileDialog();
      vistaOpenFileDialog.CheckFileExists = true;
      vistaOpenFileDialog.DefaultExt = extension;
      vistaOpenFileDialog.Multiselect = false;

      vistaOpenFileDialog.ShowDialog();

      return vistaOpenFileDialog.FileName;
    }
  }
}