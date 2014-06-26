using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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

    public string ConvertBitmapToBase64(Bitmap bitmap, ImageFormat imageFormat)
    {
      if (bitmap == null)
      {
        throw new ArgumentNullException("bitmap");
      }

      if (imageFormat == null)
      {
        throw new ArgumentNullException("imageFormat");
      }

      string result;

      using (var ms = new MemoryStream())
      {
        bitmap.Save(ms, imageFormat);
        result = Convert.ToBase64String(ms.ToArray());
      }

      return result;
    }
  }
}