using TechTalk.SpecFlow;

namespace SpecLogLogoReplacer.Tests
{
  [Binding]
  public class SaveSettingsStepDefinitions
  {
    private Settings settings;

    [Given(@"I have these settings")]
    public void GivenIHaveTheseSettings(Table table)
    {
      string pathToSpecLogHtmlFile = table.Rows[0]["Path to SpecLog Html File"];
      string pathToLogo = table.Rows[0]["Path to Logo"];

      this.settings = new Settings { PathToSpecLogHtmlFile = pathToSpecLogHtmlFile, PathToLogo = pathToLogo };
    }

  }

  public class Settings
  {
    public string PathToSpecLogHtmlFile { get; set; }

    public string PathToLogo { get; set; }
  }
}