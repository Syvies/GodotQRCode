using Godot;
using System;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

public partial class QRReader : Node
{
    public string DecodeFilePath(string filePath)
    {
        Image img = Image.LoadFromFile(filePath);
        return DecodeImage(img);
    }


    public string DecodeImage(Image image)
    {
        var reader = new BarcodeReaderGeneric();
        var luminance = new RGBLuminanceSource(image.GetData(), image.GetWidth(), image.GetHeight());

        var barcodeResult = reader.Decode(luminance);

        return barcodeResult == null ? "" : barcodeResult.Text;
    }


    public Image EncodeMessageImage(string message)
    {
        Bitmap bmp = EncodeMessage(message);
        return bmp.ConvertToImage();
    }


    public Bitmap EncodeMessage(string message)
    {
        QrCodeEncodingOptions options = new QrCodeEncodingOptions
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 256,
            Height = 256
        };

        BarcodeWriterGeneric writer = new BarcodeWriterGeneric();
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = options;

        if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
        {
            GD.PrintErr("Message empty");
            return null;
        }
        else
        {
            return GetBitmap(writer.Encode(message));
        }
    }


    private Bitmap GetBitmap(BitMatrix matrix)
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
