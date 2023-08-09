@tool
extends EditorPlugin

const NODE_NAME: String = "QRCode"
const NODE_INHERITANCE: String = "Node"
const NODE_SCRIPT: Script = preload("res://addons/QRCodeScanner/QRCodeNode.gd")
const NODE_ICON: Texture2D = preload("res://addons/QRCodeScanner/icon.png")

func _enter_tree() -> void:
	# Initialization of the plugin goes here.
	add_custom_type(NODE_NAME, NODE_INHERITANCE, NODE_SCRIPT, NODE_ICON)


func _exit_tree() -> void:
	# Clean-up of the plugin goes here.
	remove_custom_type(NODE_NAME)
