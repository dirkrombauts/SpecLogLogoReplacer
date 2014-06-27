using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

using NFluent;

using SpecLogLogoReplacer.UI;

using TechTalk.SpecFlow;

namespace SpecLogLogoReplacer.Tests
{
  [Binding]
  public class SaveSettingsStepDefinitions
  {
    private readonly IFileSystem fileSystem;

    private Settings settings;

    private readonly SettingsSaver settingsSaver;

    public SaveSettingsStepDefinitions()
    {
      this.fileSystem = new MockFileSystem();
      this.settingsSaver = new SettingsSaver(this.fileSystem);
    }

    [Given(@"I have these settings")]
    public void GivenIHaveTheseSettings(Table table)
    {
      string pathToSpecLogHtmlFile = table.Rows[0]["Path to SpecLog Html File"];
      string pathToLogo = table.Rows[0]["Path to Logo"];

      this.settings = new Settings { PathToSpecLogHtmlFile = pathToSpecLogHtmlFile, PathToLogo = pathToLogo };
    }

    [When(@"I save the settings")]
    public void WhenISaveTheSettings()
    {
      settingsSaver.SaveSettings(@"c:\settings.xml", this.settings);
    }

    [Then(@"the settings file consists of")]
    public void ThenTheSettingsFileConsistsOf(string expectedContent)
    {
      var actualContent = this.fileSystem.File.ReadAllText(@"c:\settings.xml");

      Check.That(actualContent).IsEqualTo(expectedContent);
    }
  }
}