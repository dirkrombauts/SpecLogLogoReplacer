using System;
using System.Drawing.Imaging;

using Aim.SpecLogLogoReplacer.Tests.Properties;
using Aim.SpecLogLogoReplacer.UI;

using NFluent;

using NUnit.Framework;

namespace Aim.SpecLogLogoReplacer.Tests
{
  [TestFixture]
  public class LogoReplacerTests
  {
    [Test]
    public void Replace_NullHtmlFile_ThrowsArgumentNullExceptionForHtmlFile()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace(null, null, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "htmlFile");
    }

    private static LogoReplacer CreateLogoReplacer()
    {
      var logoReplacer = new LogoReplacer();
      return logoReplacer;
    }

    [Test]
    public void Replace_NewLogoNull_ThrowsArgumentNullExceptionForNewLogo()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace("<html />", null, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "newLogo");
    }

    [Test]
    public void Replace_ImageFormatNull_ThrowsArgumentNullExceptionForImageFormat()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace("<html />", Resources.logo, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "imageFormat");
    }

    [Test]
    public void ConvertBitmapToBase64_NullBitmap_ThrowsArgumentNullExceptionForBitmap()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.ConvertBitmapToBase64(null, ImageFormat.Png))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "bitmap");
    }

    [Test]
    public void ConvertBitmapToBase64_NullImageFormat_ThrowsArgumentNullExceptionForImageFormat()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.ConvertBitmapToBase64(Resources.logo, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "imageFormat");
    }

    [Test]
    [DescriptionAttribute("localOnly")]
    public void ConvertBitmapToBase64_ProperBitmap_ReturnsCorrectValue()
    {
      var logoReplacer = CreateLogoReplacer();

      var base64 = logoReplacer.ConvertBitmapToBase64(Resources.logo, ImageFormat.Png);

      Check.That(base64)
        .IsEqualTo("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");
    }

    [Test]
    public void Replace_HtmlFileWithDifferentLogo_ShouldThrowArgumentOutOfRangeException()
    {
      var logoReplacer = CreateLogoReplacer();

      Check.ThatCode(() => logoReplacer.Replace("", Resources.logo, ImageFormat.Png))
        .Throws<ArgumentException>()
        .WithMessage("The SpecLog Exported Html file did not contain the default SpecLog logo. Did you replace it already?");
    }
  }
}