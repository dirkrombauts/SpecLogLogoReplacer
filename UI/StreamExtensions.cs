using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Aim.SpecLogLogoReplacer.UI
{
  internal static class StreamExtensions
  {
    internal static void Serialize<T>(this System.IO.Stream stream, T item)
    {
      using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
      {
        new DataContractSerializer(typeof(T)).WriteObject(writer, item);
      }
    }

    internal static T Deserialize<T>(this System.IO.Stream stream)
    {
      T result;

      try
      {
        using (XmlReader reader = XmlReader.Create(stream))
        {
          result = (T)new DataContractSerializer(typeof(T)).ReadObject(reader);
        }
      }
      catch (SerializationException)
      {
        result = default(T);
      }

      return result;
    }
  }
}