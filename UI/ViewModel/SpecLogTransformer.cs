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
    {
      this.fileSystem = new FileSystem();
    }

    public SpecLogTransformer(IFileSystem fileSystem)
    {
      this.fileSystem = fileSystem;
    }

    public void Transform(string pathToSpecLogFile, string pathToLogo)
    {
      var specLogFile = this.fileSystem.File.ReadAllText(pathToSpecLogFile);

      Image newLogo;

      using (var stream = this.fileSystem.File.OpenRead(pathToLogo))
      {
        newLogo = Image.FromStream(stream);
      }

      var patchedSpecLogFile = new LogoReplacer().Replace(specLogFile, newLogo, ImageFormat.Png);

      this.fileSystem.File.WriteAllText(pathToSpecLogFile, patchedSpecLogFile);
    }
  }
}