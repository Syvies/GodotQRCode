extends Node
class_name QRCodeEncoder


func encode() -> Image:
	print("ENCODING... lol nope")
	return generate_image(Vector2(25, 25), Color.WHITE, "res://test.png")


func generate_image(size: Vector2, color: Color, file_name: String) -> Image:
	var img: Image = Image.new()
	img.create(size.x, size.y, false, Image.FORMAT_RGBA8)
	img.fill(color)
	#img.save_png(file_name)
	return img
