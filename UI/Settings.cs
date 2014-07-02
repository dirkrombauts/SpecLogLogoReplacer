using System;
using System.Runtime.Serialization;

namespace Aim.SpecLogLogoReplacer.UI
{
  [DataContract(Name = "specLogLogoReplacer", Namespace = "")]
  public class Settings
  {
    [DataMember(Name = "pathToSpecLogHtmlFile")]
    public string PathToSpecLogHtmlFile { get; set; }

    [DataMember(Name = "pathToSpecLogo")]
    public string PathToLogo { get; set; }
  }
}