'use strict';
var iothub = require('azure-iothub');
var connectionString = 'HostName=RaspberryIO.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=eYKOimO9kId9ckwsjJ9oLoJc6HPdXWzqdndkcFIdedM=';
var registry = iothub.Registry.fromConnectionString(connectionString);
var device = new iothub.Device(null);
device.deviceId = 'myFirstNodeDevice';
registry.create(device, function(err, deviceInfo, res){
	if (err) {
	  registry.get(device.deviceId, printDeviceInfo);
	}
	if (deviceInfo) {
	  printDeviceInfo(err, deviceInfo, res)
	}
	});


function printDeviceInfo(err, deviceInfo, res){
	if (deviceInfo) {
		console.log('Device ID: ' + deviceInfo.deviceId);
		console.log('Device Key: ' + deviceInfo.authentication.symmetricKey.primaryKey);
		}
	}
		