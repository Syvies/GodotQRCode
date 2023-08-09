extends Node

@onready var qr_code: Node = $QRCode
@onready var sprite_2d: Sprite2D = $Node2D/Sprite2D


func _ready() -> void:
	var img: Image = qr_code.get_qr_code()
	var new_texture: ImageTexture = ImageTexture.new()
	new_texture.create_from_image(img)
	sprite_2d.texture = ImageTexture.create_from_image(img)
