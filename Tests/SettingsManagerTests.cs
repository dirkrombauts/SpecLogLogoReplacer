using System;
using System.IO.Abstractions.TestingHelpers;

using NFluent;

using NUnit.Framework;

using SpecLogLogoReplacer.UI;

namespace SpecLogLogoReplacer.Tests
{
  [TestFixture]
  public class SettingsManagerTests
  {
    [Test]
    public void Constructor_NullFileSystem_ThrowsArgumentNullException()
    {
      Check.ThatCode(() => new SettingsManager(null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "fileSystem");
    }

    [Test]
    public void LoadSettings_NullPath_ThrowArgumentNullException()
    {
      var settingsManager = new SettingsManager(new MockFileSystem());

      Check.ThatCode(() => settingsManager.LoadSettings(null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "path");
    }

    [Test]
    public void LoadSettings_WhiteSpacePath_ThrowArgumentNullException()
    {
      var settingsManager = new SettingsManager(new MockFileSystem());

      Check.ThatCode(() => settingsManager.LoadSettings(" \t\n\r"))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "path");
    }

    [Test]
    public void SaveSettings_NullPath_ThrowArgumentNullException()
    {
      var settingsManager = new SettingsManager(new MockFileSystem());

      Check.ThatCode(() => settingsManager.SaveSettings(null, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "path");
    }

    [Test]
    public void SaveSettings_WhiteSpacePath_ThrowArgumentNullException()
    {
      var settingsManager = new SettingsManager(new MockFileSystem());

      Check.ThatCode(() => settingsManager.SaveSettings(" \t\n\r", null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "path");
    }

    [Test]
    public void SaveSettings_NullSettings_ThrowArgumentNullExceptionForSettings()
    {
      var settingsManager = new SettingsManager(new MockFileSystem());

      Check.ThatCode(() => settingsManager.SaveSettings(@"c:\settings.xml", null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "settings");
    }
  }
}