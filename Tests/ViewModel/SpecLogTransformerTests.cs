using System;
using System.Drawing.Imaging;
using System.IO.Abstractions.TestingHelpers;

using NFluent;

using NUnit.Framework;

using SpecLogLogoReplacer.Tests.Properties;
using SpecLogLogoReplacer.UI;
using SpecLogLogoReplacer.UI.ViewModel;

namespace SpecLogLogoReplacer.Tests.ViewModel
{
  [TestFixture]
  public class SpecLogTransformerTests
  {
    [Test]
    public void Transform_NullPathToSpecLogFile_ThrowsArgumentNullExceptionForPathToSpecLogFile()
    {
      var transformer = CreateSpecLogTransformer();

      Check.ThatCode(() => transformer.Transform(null, null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "pathToSpecLogFile");
    }

    private static SpecLogTransformer CreateSpecLogTransformer()
    {
      var transformer = new SpecLogTransformer(new MockFileSystem());
      return transformer;
    }

    [Test]
    public void Transform_NullPathToLogoFile_ThrowsArgumentNullExceptionForPathToSpecLogFile()
    {
      var transformer = CreateSpecLogTransformer();

      Check.ThatCode(() => transformer.Transform(@"c:\speclog.html", null))
        .Throws<ArgumentNullException>()
        .WithProperty("ParamName", "pathToLogo");
    }

    [Test]
    public void Transform_PathToSpecLogFileStartsWithDoubleQuote_ShouldNotThrowArgumentException()
    {
      var mockFileSystem = CreateFileSystemWithSimpleHtmlAndDefaultLogo();
      var transformer = CreateSpecLogTransformer(mockFileSystem);

      Check.ThatCode(() => transformer.Transform(@"""c:\speclog.html", @"c:\logo.png"))
        .DoesNotThrow();
    }

    private static MockFileSystem CreateFileSystemWithSimpleHtmlAndDefaultLogo()
    {
      var mockFileSystem = new MockFileSystem();
      mockFileSystem.AddFile(@"c:\speclog.html", new MockFileData("<html />"));
      mockFileSystem.AddFile(@"c:\logo.png", new MockFileData(LogoReplacer.ConvertTo(Resources.logo, ImageFormat.Png)));
      return mockFileSystem;
    }

    private static SpecLogTransformer CreateSpecLogTransformer(MockFileSystem mockFileSystem)
    {
      var transformer = new SpecLogTransformer(mockFileSystem);
      return transformer;
    }
  }
}