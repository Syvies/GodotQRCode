extends Node

@onready var qr_code: Node = $QRCode
@onready var texture_rect: TextureRect = $CenterContainer/PanelContainer/TextureRect


func _ready() -> void:
	var image_path: String = "res://test.png"
	#var image_path: String = "D:\\Documents (D)\\Godot\\QRCode Scanner\\test.png"
	var image_file: Image = Image.load_from_file(image_path)

	print(qr_code.DecodeFilePath(image_path))
	print(qr_code.Decode(image_file))

	var img: Image = qr_code.EncodeImage("Test numéro 2")
	var tex: ImageTexture = ImageTexture.create_from_image(img)
	texture_rect.texture = tex
