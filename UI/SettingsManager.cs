using System;
using System.IO.Abstractions;

namespace Aim.SpecLogLogoReplacer.UI
{
  public class SettingsManager
  {
    private readonly IFileSystem fileSystem;

    public SettingsManager(IFileSystem fileSystem)
    {
      if (fileSystem == null) throw new ArgumentNullException("fileSystem");

      this.fileSystem = fileSystem;
    }

    public void SaveSettings(string path, Settings settings)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (settings == null) throw new ArgumentNullException("settings");

      using (var stream = this.fileSystem.File.OpenWrite(path))
      {
        stream.Serialize<Settings>(settings);
      }
    }

    public Settings LoadSettings(string path)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");

      Settings result;

      using (var stream = this.fileSystem.File.OpenRead(path))
      {
        result = stream.Deserialize<Settings>();
      }

      return result;
    }
  }
}