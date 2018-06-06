var request = require("request")
function getJson(jsonFileUrl)
{
    request.get(jsonFileUrl, function (error, response, body) {

        if (!error && response.statusCode === 200) {
            var json = body;
            return res.send(json);
        }
    });
}

  