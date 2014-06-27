using System;
using System.IO.Abstractions;

namespace SpecLogLogoReplacer.UI
{
  public class SettingsManager
  {
    private readonly IFileSystem fileSystem;

    public SettingsManager(IFileSystem fileSystem)
    {
      this.fileSystem = fileSystem;
    }

    public void SaveSettings(string path, Settings settings)
    {
      using (var stream = this.fileSystem.File.OpenWrite(path))
      {
        stream.Serialize<Settings>(settings);
      }
    }

    public Settings LoadSettings(string path)
    {
      Settings result;

      using (var stream = this.fileSystem.File.OpenRead(path))
      {
        result = stream.Deserialize<Settings>();
      }

      return result;
    }
  }
}