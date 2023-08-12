extends Node

@onready var qr_code: Node = $QRCode
@onready var texture_rect: TextureRect = $Center/Panel/VBox/TextureRect
@onready var line_edit: LineEdit = $Center/Panel/VBox/LineEdit
@onready var file_dialog: FileDialog = $FileDialog

var image_to_save: Image = null


func _ready() -> void:
	var image_path: String = "res://test.png"
	var image_file: Image = Image.load_from_file(image_path)

	# Decode a QR code using a file path (returns a String)
	print(qr_code.DecodeFilePath(image_path))

	# Decode a QR code using an Image (returns a String)
	print(qr_code.DecodeImage(image_file))


func _on_generate_button_pressed() -> void:
	# Generate a QR code Image from the text message
	image_to_save = qr_code.EncodeMessageImage(line_edit.text)

	# display the generated QR code Image on screen
	var tex: ImageTexture = ImageTexture.create_from_image(image_to_save)
	texture_rect.texture = tex


func _on_save_button_pressed() -> void:
	file_dialog.show()


func _on_file_dialog_file_selected(path: String) -> void:
	image_to_save.save_png(path)
