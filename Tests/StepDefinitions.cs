using System;
using System.Drawing;
using System.Drawing.Imaging;

using Aim.SpecLogLogoReplacer.Tests.Properties;
using Aim.SpecLogLogoReplacer.UI;

using NFluent;

using TechTalk.SpecFlow;

namespace Aim.SpecLogLogoReplacer.Tests
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

      try
      {
        this.htmlFile = new LogoReplacer().Replace(this.htmlFile, newLogo, ImageFormat.Png);
      }
      catch (Exception exception)
      {
        this.messageToUser = exception.Message;
      }
    }

    [Then(@"the html file should contain")]
    public void ThenTheHtmlFileShouldContain(string multilineText)
    {
      Console.Out.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture);
      Check.That(this.htmlFile).Contains(multilineText);
    }

    [Then(@"I should see a message saying")]
    public void ThenIShouldSeeAMessageSaying(string expectedMessage)
    {
      Check.That(this.messageToUser).StartsWith(expectedMessage);
    }
  }
}
