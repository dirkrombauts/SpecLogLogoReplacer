using System;
using System.IO.Abstractions;

namespace SpecLogLogoReplacer.UI
{
  public class SettingsSaver
  {
    private readonly IFileSystem fileSystem;

    public SettingsSaver(IFileSystem fileSystem)
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
  }
}