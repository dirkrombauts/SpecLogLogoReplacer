using System;
using System.Drawing;

namespace SpecLogLogoReplacer.UI
{
  public class LogoReplacer
  {
    public string Replace(string htmlFile, Bitmap newLogo)
    {
      if (htmlFile == null)
      {
        throw new ArgumentNullException("htmlFile");
      }

      if (newLogo == null)
      {
        throw new ArgumentNullException("newLogo");
      }

      return null;
    }
  }
}