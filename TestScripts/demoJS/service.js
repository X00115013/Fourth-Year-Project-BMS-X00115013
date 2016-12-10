var http = require('http');
http.CreateServer(function(req, res){
	res.end('Hello World');
}).listen(process.env.port);
