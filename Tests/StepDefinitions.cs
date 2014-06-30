using System;
using System.Drawing;
using System.Drawing.Imaging;

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

    private string messageToUser;

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

      this.htmlFile = new LogoReplacer().Replace(this.htmlFile, newLogo, ImageFormat.Png);
    }

    [Then(@"the html file should contain")]
    public void ThenTheHtmlFileShouldContain(string multilineText)
    {
      Check.That(this.htmlFile).Contains(multilineText);
    }

    [Then(@"I should see a message saying")]
    public void ThenIShouldSeeAMessageSaying(string expectedMessage)
    {
      Check.That(this.messageToUser).IsEqualTo(expectedMessage);
    }
  }
}
