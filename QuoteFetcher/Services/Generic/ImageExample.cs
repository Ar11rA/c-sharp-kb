using System.Reflection;
using SixLabors.ImageSharp;
using SkiaSharp;

namespace QuoteFetcher.Services.Generic;

public static class ImageExample
{
    public static void GetDetails(string path)
    {
        // Magic numbers
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream(path)!;
        BinaryReader reader = new(stream);
        byte[] buffer = reader.ReadBytes(4);
        string hex = BitConverter.ToString(buffer);
        Console.WriteLine("Magic numbers: " + hex);

        // image dimensions
        stream = assembly.GetManifestResourceStream(path)!;
        IImageInfo imageInfo = Image.Identify(stream);
        Console.WriteLine($"{imageInfo.Width}x{imageInfo.Height} | BPP: {imageInfo.PixelType.BitsPerPixel}");

        stream = assembly.GetManifestResourceStream(path)!;
        SKImageInfo? bm = SKBitmap.DecodeBounds(stream);
        Console.WriteLine($"{bm.Value.Height}x{bm.Value.Height}");
    }
}
