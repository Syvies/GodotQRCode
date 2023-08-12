
# GodotQRCode
A Godot QR Code scanner and reader made in C# using the [.NET ZXing library](https://github.com/micjahn/ZXing.Net)
## Getting started
### Prerequisite
- This addon is made for `Godot 4.1.1 Mono` as it requires C#.
- You need to have at least one C# script to be able to build the code and also have access to the `.csproj` file.
### Installing
- In your project `.csproj` file, add the following line `<PackageReference Include="ZXing.Net" Version="0.16.9" />`. Your `.csproj` file should look something like this:
```XML
<Project Sdk="Godot.NET.Sdk/4.1.1">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <EnableDynamicLoading>true</EnableDynamicLoading>
    <RootNamespace>MyProjectName</RootNamespace>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="ZXing.Net" Version="0.16.9" />
  </ItemGroup>
</Project>
```
- Put the `addons/QRCodeScanner` folder in your addons folder in the root of your Godot project.
- Don't forget to build your project.
## How to use
### Adding the node
Add the `QRCode` node to your scene and get a reference to it in your code.
### Reading a QR code
There are two ways to read a QR code:
- `public string DecodeFilePath(string filePath)` to decode using a file path to an image containing a QR code.
- `public string DecodeImage(Image image)` to decode using an Image object containing a QR code.

Here is the code example you can find in [main.gd](https://github.com/Syvies/GodotQRCode/blob/main/main.gd):
```GDScript
	var image_path: String = "res://test.png"
	var image_file: Image = Image.load_from_file(image_path)

	# Decode a QR code using a file path (returns a String)
	print(qr_code.DecodeFilePath(image_path))

	# Decode a QR code using an Image (returns a String)
	print(qr_code.DecodeImage(image_file))
```
### Creating a QR code
- `public Bitmap EncodeMessage(string message)` to generate a Bitmap containing the message as a QR code.
- `public Image EncodeMessageImage(string message)` to generate an Image containing the message as a QR code.

Here is the code example you can find in [main.gd](https://github.com/Syvies/GodotQRCode/blob/main/main.gd):
```GDScript
	# Generate a QR code Image from the text message
	var img: Image = qr_code.EncodeMessageImage("Ceci est un test")

	# display the generated QR code Image on screen
	var tex: ImageTexture = ImageTexture.create_from_image(img)
	texture_rect.texture = tex
```
## Authors
- [Syvies](https://github.com/Syvies) - *Initial work* - 
## License
The source code is available under the MIT license. For more information, check the [LICENSE](https://github.com/Syvies/GodotQRCode/blob/main/LICENSE) file.
