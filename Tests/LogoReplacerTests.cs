using System;

using NFluent;

using NUnit.Framework;

using SpecLogLogoReplacer.UI;

namespace SpecLogLogoReplacer.Tests
{
  [TestFixture]
  public class LogoReplacerTests
  {
    [Test]
    public void Replace_NullHtmlFile_ThrowsArgumentNullExceptionForHtmlFile()
    {
      var logoReplacer = new LogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace(null, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "htmlFile");
    }

    [Test]
    public void Replace_NotNullHtmlFileButNewLogoNull_ThrowsArgumentNullExceptionForNewLogo()
    {
      var logoReplacer = new LogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace("<html />", null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "newLogo");
    }
  }
}