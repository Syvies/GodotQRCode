using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

public partial class QRReader : Node
{
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here.
        GD.Print("Hello from C# to Godot :)");
    }


    public string DecodeFilePath(string filePath)
    {
        //"D:\\Documents (D)\\Godot\\QRCode Scanner\\test.png"
        Image img = Image.LoadFromFile(filePath);
        return Decode(img);
    }


    public string Decode(Image image)
    {
        var reader = new BarcodeReaderGeneric();
        var luminance = new RGBLuminanceSource(image.GetData(), image.GetWidth(), image.GetHeight());

        var barcodeResult = reader.Decode(luminance);

        return barcodeResult == null ? "" : barcodeResult.Text;
    }


    public Image EncodeImage(string message)
    {
        Bitmap bmp = Encode(message);
        return bmp.ConvertToImage();
    }


    public Bitmap Encode(string message)
    {
        var options = new QrCodeEncodingOptions
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 256,
            Height = 256
        };

        var writer = new BarcodeWriterGeneric();
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = options;

        if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
        {
            GD.PrintErr("Message empty");
            return null;
        }
        else
        {
            var result = writer.Encode(message);

            return GetBitmap(result);
        }
    }


    public Bitmap GetBitmap(BitMatrix matrix)
    {
        Vector2I imageSize = new Vector2I(matrix.Width, matrix.Height);


        Bitmap result = new Bitmap();
        result.Create(imageSize);

        for (int i = 0; i < matrix.Width; i++)
        {
            for (int j = 0; j < matrix.Height; j++)
            {
                result.SetBit(i, j, !matrix[i, j]);
            }
        }

        return result;
    }

}
