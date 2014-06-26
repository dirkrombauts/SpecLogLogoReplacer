using System;
using System.Drawing;

using NFluent;

using SpecLogLogoReplacer.Tests.Properties;
using SpecLogLogoReplacer.UI;

using TechTalk.SpecFlow;

namespace SpecLogLogoReplacer.Tests
{
  [Binding]
  public class StepDefinitions
  {
    private string htmlFile;

    [Given(@"I have the html file exported from SpecLog contains")]
    public void GivenIHaveTheHtmlFileExportedFromSpecLogContains(string multilineText)
    {
      this.htmlFile = multilineText;
    }

    [When(@"I replace the logo with file '(.*)'")]
    public void WhenIReplaceTheLogoWithFile(string fileName)
    {
      Bitmap newLogo;

      switch ((fileName ?? string.Empty).ToLowerInvariant())
      {
        case "logo.png":
          {
            newLogo = Resources.logo;
            break;
          }

        default:
          {
            throw new ArgumentOutOfRangeException(string.Format("Unknown logo file '{0}'", fileName));
          }
      }

      this.htmlFile = new LogoReplacer().Replace(this.htmlFile, newLogo);
    }

    [Then(@"the html file should contain")]
    public void ThenTheHtmlFileShouldContain(string multilineText)
    {
      Check.That(this.htmlFile).Contains(multilineText);
    }
  }
}
