/*module.exports = function(){
    var express = require('express');
    var router = express.Router();

    function getTops(res, mysql, context, complete){
        mysql.pool.query("SELECT t.ID, t.Type, t.Color, i.path AS path, zi.path AS zpath FROM top AS t, image AS i, zoomed_image AS zi;", function(error, results, fields){
            if(error){
                res.write(JSON.stringify(error));
                console.log(JSON.stringify(error));
                res.end();
            }
            context.top = results;
            complete();
        });
    }

    router.get('/', function(req, res){
        console.log("test1");
        var callbackCount = 0;
        var context = {};
        var mysql = req.app.get('mysql');
        console.log("test2");
        getTops(res, mysql, context, complete);
        console.log("test3");
        function complete(){
            callbackCount++;
            console.log("testloop");
            if(callbackCount >= 1){
                res.render('top', context);
            }
        }
    });

    return router;
}; */

const express = require('express');
var router = express.Router();
module.exports = router;

router.get('/', function(req, res){
    console.log("here");
    res.render('outfitbuilder');
});
