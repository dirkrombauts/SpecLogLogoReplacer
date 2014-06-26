﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SpecLogLogoReplacer.UI
{
  public class LogoReplacer
  {
    private const string SpecRunLogoSequence =
@"            <div class=""logo"">
                <a href=""http://www.speclog.net/"">
                    <img title=""Visit SpecLog.net"" alt=""SpecLog logo"" src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAO4AAAA9CAIAAAAlJsL0AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyBpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYwIDYxLjEzNDc3NywgMjAxMC8wMi8xMi0xNzozMjowMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNSBXaW5kb3dzIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjVGRTBCRUVGMjQ4OTExRTBBRDg2QzE1OTgxRTMxNzVDIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjVGRTBCRUYwMjQ4OTExRTBBRDg2QzE1OTgxRTMxNzVDIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6NUZFMEJFRUQyNDg5MTFFMEFEODZDMTU5ODFFMzE3NUMiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6NUZFMEJFRUUyNDg5MTFFMEFEODZDMTU5ODFFMzE3NUMiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz5+6z/nAAAkgElEQVR42ux9CZhUxbl2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"" />
                </a>
            </div>";

    private const string CustomLogoFormatString =
@"            <div class=""logo"">
                <img alt=""Logo"" src=""data:image/png;base64,{0}"" />
            </div>";

    public string Replace(string htmlFile, Image newLogo, ImageFormat imageFormat)
    {
      if (htmlFile == null)
      {
        throw new ArgumentNullException("htmlFile");
      }

      if (newLogo == null)
      {
        throw new ArgumentNullException("newLogo");
      }

      string result = htmlFile.Replace(
        SpecRunLogoSequence, 
        string.Format(CustomLogoFormatString, ConvertBitmapToBase64(newLogo, imageFormat)));

      return result;
    }

    public string ConvertBitmapToBase64(Image bitmap, ImageFormat imageFormat)
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