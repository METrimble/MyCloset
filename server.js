const express = require('express');
var router = express.Router();
module.exports = router;

const mysql = require('mysql2');

//Create Connection to mysql
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'my$pass',
    database: 'mycloset'
});

//query to show all tops
function getTops(res, context, complete){
    db.query("SELECT t.ID, t.Type, t.Color, i.path AS path, zi.path AS zpath FROM top AS t INNER JOIN image AS i ON t.image_id = i.ID INNER JOIN zoomed_image AS zi ON t.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.tops = results;
            complete();
        }
    });
}

//query to show all bottoms
function getBottoms(res, context, complete){
    db.query("SELECT b.ID, b.Type, b.Color, i.path AS path, zi.path AS zpath FROM bottom AS b INNER JOIN image AS i ON b.image_id = i.ID INNER JOIN zoomed_image AS zi ON b.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.bottoms = results;
            complete();
        }
    });
}

function getDresses(res, context, complete){
    db.query("SELECT d.ID, d.Dress_Length, d.Color, d.Sleeve_Length, i.path AS path, zi.path AS zpath FROM dress AS d INNER JOIN image AS i ON d.image_id = i.ID INNER JOIN zoomed_image AS zi ON d.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.dresses = results;
            complete();
        }
    });
}

function getSocks(res, context, complete){
    db.query("SELECT s.ID, s.Length, s.Color, i.path AS path, zi.path AS zpath FROM sock AS s INNER JOIN image AS i ON s.image_id = i.ID INNER JOIN zoomed_image AS zi ON s.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.socks = results;
            complete();
        }
    });
}

function getShoes(res, context, complete){
    db.query("SELECT s.ID, s.Type, s.Color, i.path AS path, zi.path AS zpath FROM shoe AS s INNER JOIN image AS i ON s.image_id = i.ID INNER JOIN zoomed_image AS zi ON s.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.shoes = results;
            complete();
        }
    });
}

function getAccessories(res, context, complete){
    db.query("SELECT a.ID, a.Type, a.Color, i.path AS path, zi.path AS zpath FROM accessory AS a INNER JOIN image AS i ON a.image_id = i.ID INNER JOIN zoomed_image AS zi ON a.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.accessories = results;
            complete();
        }
    });
}

function getBags(res, context, complete){
    db.query("SELECT b.ID, b.Type, b.Color, i.path AS path, zi.path AS zpath FROM bag AS b INNER JOIN image AS i ON b.image_id = i.ID INNER JOIN zoomed_image AS zi ON b.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.bags = results;
            complete();
        }
    });
}

function getOuterwear(res, context, complete){
    db.query("SELECT o.ID, o.Type, o.Color, i.path AS path, zi.path AS zpath FROM outerwear AS o INNER JOIN image AS i ON o.image_id = i.ID INNER JOIN zoomed_image AS zi ON o.zoomed_image_id = zi.ID;", (err, results) => {
        if(err){
            console.log(err);
        }
        else{
            context.outerwear = results;
            complete();
        }
    });
}

//view all clothing items
router.get('/', function(req, res){
    var context = {};
    var counter = 0;
    
    getTops(res, context, complete);
    getBottoms(res, context, complete);
    getDresses(res, context, complete);
    getSocks(res, context, complete);
    getShoes(res, context, complete);
    getAccessories(res, context, complete);
    getBags(res, context, complete);
    getOuterwear(res, context, complete);

    function complete(){
        counter = counter + 1;
        if(counter >= 8){
            res.render('outfitbuilder', context);
        }
    }
});

