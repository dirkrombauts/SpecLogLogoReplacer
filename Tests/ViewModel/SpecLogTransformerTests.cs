using System;
using System.IO.Abstractions.TestingHelpers;

using NFluent;

using NUnit.Framework;

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
  }
}