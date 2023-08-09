extends Node

var scanner: QRCodeScanner = QRCodeScanner.new()
var encoder: QRCodeEncoder = QRCodeEncoder.new()

func get_qr_code() -> Image:
	return encoder.encode()
