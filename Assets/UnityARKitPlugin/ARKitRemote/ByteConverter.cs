using System.IO;
using System.IO.Compression;

namespace UnityEngine.XR.iOS
{
  public static class ByteConverter
  {

    /// <summary>
    /// Compress using deflate.
    /// </summary>
    /// <returns>The byte compress.</returns>
    /// <param name="source">Source.</param>
    public static byte[] ConvertByteCompress(byte[] source)
    {
      using (MemoryStream ms = new MemoryStream())
      using (DeflateStream compressedDStream = new DeflateStream(ms, CompressionMode.Compress, true))
      {
        compressedDStream.Write(source, 0, source.Length);

        compressedDStream.Close();

        byte[] destination = ms.ToArray();

        Debug.Log(source.Length.ToString() + " vs " + ms.Length.ToString());

        return destination;
      }
    }

    /// <summary>
    /// Decompress using deflate.
    /// </summary>
    /// <returns>The byte decompress.</returns>
    /// <param name="source">Source.</param>
    public static byte[] ConvertByteDecompress(byte[] source)
    {
      using (MemoryStream input = new MemoryStream(source))
      using (MemoryStream output = new MemoryStream())
      using (DeflateStream decompressedDstream = new DeflateStream(input, CompressionMode.Decompress))
      {
        decompressedDstream.CopyTo(output);

        byte[] destination = output.ToArray();

        Debug.Log("Decompress Size : " + output.Length);

        return destination;
      }
    }
  }
}
