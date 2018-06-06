'use strict';

const express = require('express');

// Constants
const PORT = 8080;
const HOST = '0.0.0.0';

//To test from command line use exact command:
// set url=https://rzshared.blob.core.windows.net/data&&node server.js
const url = process.env.url; 


// App
const app = express();
app.get('/', function (req, res) {
    res.send('App running...\n');
});
 
var request = require("request")
 
app.get('/ww1', function (req, res) {

    var jsonFileUrl = url + "/ww1.json";
    console.log(jsonFileUrl)
    request.get(jsonFileUrl, function (error, response, body) {

        if (!error && response.statusCode === 200) {
            var json = body;
            return res.send(json);
        }
    });

});

app.get('/ww2', function (req, res) {

    var jsonFileUrl = url + "/ww2.json";

    request.get(jsonFileUrl, function (error, response, body) {

        if (!error && response.statusCode === 200) {
            var json = body;
            return res.send(json);
        }
    });

});

app.get('/renaissance', function (req, res) {

    var jsonFileUrl = url + "/renaissance.json";

    request.get(jsonFileUrl, function (error, response, body) {

        if (!error && response.statusCode === 200) {
            var json = body;
            return res.send(json);
        }
    });

});
app.get('/frenchrevolution', function (req, res) {

    var jsonFileUrl = url + "/frenchrevolution.json";

    request.get(jsonFileUrl, function (error, response, body) {

        if (!error && response.statusCode === 200) {
            var json = body;
            return res.send(json);
        }
    });

});


app.listen(PORT, HOST);
console.log('Running on http://' + HOST + ':' + PORT);
console.log('Url: ' + process.env.url)