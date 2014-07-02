using System;
using System.IO.Abstractions.TestingHelpers;

using Aim.SpecLogLogoReplacer.UI;

using NFluent;

using TechTalk.SpecFlow;

namespace Aim.SpecLogLogoReplacer.Tests
{
  [Binding]
  public class LoadingAndSavingSettingsStepDefinitions
  {
    private readonly MockFileSystem fileSystem;

    private Settings settings;

    private readonly SettingsManager settingsManager;

    public LoadingAndSavingSettingsStepDefinitions()
    {
      this.fileSystem = new MockFileSystem();
      this.settingsManager = new SettingsManager(this.fileSystem);
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
      settingsManager.SaveSettings(@"c:\settings.xml", this.settings);
    }

    [Then(@"the settings file consists of")]
    public void ThenTheSettingsFileConsistsOf(string expectedContent)
    {
      var actualContent = this.fileSystem.File.ReadAllText(@"c:\settings.xml");

      Check.That(actualContent).IsEqualTo(expectedContent);
    }

    [Given(@"the settings file consists of")]
    public void GivenTheSettingsFileConsistsOf(string multilineText)
    {
      this.fileSystem.AddFile(@"c:\settings.xml", new MockFileData(multilineText));
    }

    [When(@"I load the settings")]
    public void WhenILoadTheSettings()
    {
      this.settings = settingsManager.LoadSettings(@"c:\settings.xml");
    }
  
    [Then(@"I should have these settings")]
    public void ThenIShouldHaveTheseSettings(Table table)
    {
      string pathToSpecLogHtmlFile = table.Rows[0]["Path to SpecLog Html File"];
      string pathToLogo = table.Rows[0]["Path to Logo"];

      Check.That(this.settings.PathToSpecLogHtmlFile).IsEqualTo(pathToSpecLogHtmlFile);
      Check.That(this.settings.PathToLogo).IsEqualTo(pathToLogo);
    }
  }
}