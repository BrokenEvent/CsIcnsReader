using System;
using System.Text;

namespace BrokenEvent.LibIcns
{
  public class IcnsType
  {
    private readonly int type;
    private readonly int width;
    private readonly int height;
    private readonly int bitsPerPixel;
    private readonly bool hasMask;

    public static readonly IcnsType ICNS_16x12_1BIT_IMAGE_AND_MASK = new IcnsType("icm#", 16, 12, 1, true);
    public static readonly IcnsType ICNS_16x12_4BIT_IMAGE = new IcnsType("icm4", 16, 12, 4, false);
    public static readonly IcnsType ICNS_16x12_8BIT_IMAGE = new IcnsType("icm8", 16, 12, 8, false);

    public static readonly IcnsType ICNS_16x16_8BIT_MASK = new IcnsType("s8mk", 16, 16, 8, true);
    public static readonly IcnsType ICNS_16x16_1BIT_IMAGE_AND_MASK = new IcnsType("ics#", 16, 16, 1, true);
    public static readonly IcnsType ICNS_16x16_4BIT_IMAGE = new IcnsType("ics4", 16, 16, 4, false);
    public static readonly IcnsType ICNS_16x16_8BIT_IMAGE = new IcnsType("ics8", 16, 16, 8, false);
    public static readonly IcnsType ICNS_16x16_32BIT_IMAGE = new IcnsType("is32", 16, 16, 32, false);

    public static readonly IcnsType ICNS_32x32_8BIT_MASK = new IcnsType("l8mk", 32, 32, 8, true);
    public static readonly IcnsType ICNS_32x32_1BIT_IMAGE_AND_MASK = new IcnsType("ICN#", 32, 32, 1, true);
    public static readonly IcnsType ICNS_32x32_4BIT_IMAGE = new IcnsType("icl4", 32, 32, 4, false);
    public static readonly IcnsType ICNS_32x32_8BIT_IMAGE = new IcnsType("icl8", 32, 32, 8, false);
    public static readonly IcnsType ICNS_32x32_32BIT_IMAGE = new IcnsType("il32", 32, 32, 32, false);

    public static readonly IcnsType ICNS_48x48_8BIT_MASK = new IcnsType("h8mk", 48, 48, 8, true);
    public static readonly IcnsType ICNS_48x48_1BIT_IMAGE_AND_MASK = new IcnsType("ich#", 48, 48, 1, true);
    public static readonly IcnsType ICNS_48x48_4BIT_IMAGE = new IcnsType("ich4", 48, 48, 4, false);
    public static readonly IcnsType ICNS_48x48_8BIT_IMAGE = new IcnsType("ich8", 48, 48, 8, false);
    public static readonly IcnsType ICNS_48x48_32BIT_IMAGE = new IcnsType("ih32", 48, 48, 32, false);

    public static readonly IcnsType ICNS_128x128_8BIT_MASK = new IcnsType("t8mk", 128, 128, 8, true);
    public static readonly IcnsType ICNS_128x128_32BIT_IMAGE = new IcnsType("it32", 128, 128, 32, false);

    public static readonly IcnsType ICNS_256x256_32BIT_ARGB_IMAGE = new IcnsType("ic08", 256, 256, 32, false);

    public static readonly IcnsType ICNS_512x512_32BIT_ARGB_IMAGE = new IcnsType("ic09", 512, 512, 32, false);

    private static IcnsType[] allImageTypes =
	  {
		  ICNS_16x12_1BIT_IMAGE_AND_MASK, ICNS_16x12_4BIT_IMAGE, ICNS_16x12_8BIT_IMAGE,
		  ICNS_16x16_1BIT_IMAGE_AND_MASK, ICNS_16x16_4BIT_IMAGE, ICNS_16x16_8BIT_IMAGE, ICNS_16x16_32BIT_IMAGE,
		  ICNS_32x32_1BIT_IMAGE_AND_MASK, ICNS_32x32_4BIT_IMAGE, ICNS_32x32_8BIT_IMAGE, ICNS_32x32_32BIT_IMAGE,
		  ICNS_48x48_1BIT_IMAGE_AND_MASK, ICNS_48x48_4BIT_IMAGE, ICNS_48x48_8BIT_IMAGE, ICNS_48x48_32BIT_IMAGE,
		  ICNS_128x128_32BIT_IMAGE,
		  ICNS_256x256_32BIT_ARGB_IMAGE,
		  ICNS_512x512_32BIT_ARGB_IMAGE
	  };

    private static IcnsType[] allMaskTypes =
	  {
		  ICNS_16x12_1BIT_IMAGE_AND_MASK,
		  ICNS_16x16_1BIT_IMAGE_AND_MASK, ICNS_16x16_8BIT_MASK,
		  ICNS_32x32_1BIT_IMAGE_AND_MASK, ICNS_32x32_8BIT_MASK,
		  ICNS_48x48_1BIT_IMAGE_AND_MASK, ICNS_48x48_8BIT_MASK,
		  ICNS_128x128_8BIT_MASK
	  };

    private IcnsType(string type, int width, int height, int bitsPerPixel, bool hasMask)
    {
      this.type = TypeAsInt(type);
      this.width = width;
      this.height = height;
      this.bitsPerPixel = bitsPerPixel;
      this.hasMask = hasMask;
    }

    public int Type
    {
      get { return type; }
    }

    public int Width
    {
      get { return width; }
    }

    public int Height
    {
      get { return height; }
    }

    public int BitsPerPixel
    {
      get { return bitsPerPixel; }
    }

    public bool HasMask
    {
      get { return hasMask; }
    }

    public static IcnsType FindAnyType(int type)
    {
      for (int i = 0; i < allImageTypes.Length; i++)
        if (allImageTypes[i].Type == type)
          return allImageTypes[i];

      for (int i = 0; i < allMaskTypes.Length; i++)
        if (allMaskTypes[i].Type == type)
          return allMaskTypes[i];

      return null;
    }

    public static IcnsType FindImageType(int type)
    {
      for (int i = 0; i < allImageTypes.Length; i++)
        if (allImageTypes[i].Type == type)
          return allImageTypes[i];

      return null;
    }

    public static IcnsType Find8BPPMaskType(IcnsType imageType)
    {
      for (int i = 0; i < allMaskTypes.Length; i++)
        if (allMaskTypes[i].BitsPerPixel == 8 &&
            allMaskTypes[i].Width == imageType.Width &&
            allMaskTypes[i].Height == imageType.Height)
          return allMaskTypes[i];

      return null;
    }

    public static IcnsType Find1BPPMaskType(IcnsType imageType)
    {
      for (int i = 0; i < allMaskTypes.Length; i++)
        if (allMaskTypes[i].BitsPerPixel == 1 &&
            allMaskTypes[i].Width == imageType.Width &&
            allMaskTypes[i].Height == imageType.Height)
          return allMaskTypes[i];

      return null;
    }

    public static int TypeAsInt(string type)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(type);

      if (bytes.Length != 4)
        throw new Exception("Invalid ICNS type");

      return ((0xff & bytes[0]) << 24) |
             ((0xff & bytes[1]) << 16) |
             ((0xff & bytes[2]) << 8) |
             (0xff & bytes[3]);
    }

    public static string DescribeType(int type)
    {
      byte[] bytes = new byte[4];
      bytes[0] = (byte)(0xff & (type >> 24));
      bytes[1] = (byte)(0xff & (type >> 16));
      bytes[2] = (byte)(0xff & (type >> 8));
      bytes[3] = (byte)(0xff & type);

      return Encoding.ASCII.GetString(bytes);
    }
  }
}
