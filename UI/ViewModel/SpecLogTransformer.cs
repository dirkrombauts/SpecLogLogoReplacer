using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Abstractions;

namespace SpecLogLogoReplacer.UI.ViewModel
{
  public class SpecLogTransformer : ISpecLogTransformer
  {
    private readonly IFileSystem fileSystem;

    public SpecLogTransformer()
      : this (new FileSystem())
    {
    }

    public SpecLogTransformer(IFileSystem fileSystem)
    {
      this.fileSystem = fileSystem;
    }

    public void Transform(string pathToSpecLogFile, string pathToLogo)
    {
      if (pathToSpecLogFile == null)
      {
        throw new ArgumentNullException("pathToSpecLogFile");
      }

      if (pathToLogo == null)
      {
        throw new ArgumentNullException("pathToLogo");
      }

      pathToSpecLogFile = SanitizePath(pathToSpecLogFile);
      pathToLogo = SanitizePath(pathToLogo);

      var specLogFile = LoadSpecLogHtmlFile(pathToSpecLogFile);

      var newLogo = LoadLogo(pathToLogo);

      var patchedSpecLogFile = PatchSpecLogFile(specLogFile, newLogo);

      this.fileSystem.File.WriteAllText(pathToSpecLogFile, patchedSpecLogFile);
    }

    private static string PatchSpecLogFile(string specLogFile, Image newLogo)
    {
      var patchedSpecLogFile = new LogoReplacer().Replace(specLogFile, newLogo, ImageFormat.Png);
      return patchedSpecLogFile;
    }

    private string LoadSpecLogHtmlFile(string pathToSpecLogFile)
    {
      var specLogFile = this.fileSystem.File.ReadAllText(pathToSpecLogFile);
      return specLogFile;
    }

    private Image LoadLogo(string pathToLogo)
    {
      Image newLogo;

      using (var stream = this.fileSystem.File.OpenRead(pathToLogo))
      {
        newLogo = Image.FromStream(stream);
      }
      return newLogo;
    }

    private static string SanitizePath(string pathToSpecLogFile)
    {
      if (pathToSpecLogFile.StartsWith("\""))
      {
        pathToSpecLogFile = pathToSpecLogFile.Substring(1);
      }

      if (pathToSpecLogFile.EndsWith("\""))
      {
        pathToSpecLogFile = pathToSpecLogFile.Substring(0, pathToSpecLogFile.Length - 1);
      }
      return pathToSpecLogFile;
    }
  }
}