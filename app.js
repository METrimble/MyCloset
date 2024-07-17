//reference used: https://www.youtube.com/watch?v=EN6Dx22cPRI&ab_channel=TraversyMedia
const express = require('express');
//const mysql = require('mysql2'); //update avoids error relating to connection
const { engine } = require('express-handlebars');
const bodyParser = require('body-parser');

require('dotenv').config();

//Create Connection to mysql
/*const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'my$pass',
    database: 'mycloset'
}); */

const app = express();

//handlebars
app.engine('handlebars', engine({ 
//    defaultLayout: "main"
}));
app.set('view engine', 'handlebars');


//static pages
app.use(express.static("static"));

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());

//load homepage
app.get('/', function (req, res) {
    res.render('homepage');
});

app.use('/outfitbuilder', require('./server.js'));
/*
//load outfit builder
app.get('/outfitbuilder', function (req, res) {
    console.log("rendering outfitbuilder");
    res.render('outfitbuilder');
});*/

//load outfit viewer
app.get('/outfitviewer', function (req, res) {
    res.render('outfitviewer');
});

/*
//connect mysql
db.connect((err) => {
    if(err){
        throw err;
    }
    console.log('MySQL connected..');
}); */

//listen on port 3000
app.listen('3000', () => {
    console.log('Server started on port');
});