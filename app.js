//reference used: https://www.youtube.com/watch?v=EN6Dx22cPRI&ab_channel=TraversyMedia

const express = require('express');
const mysql = require('mysql2'); //update avoids error relating to connection
const { engine } = require('express-handlebars');

//Create Connection to mysql
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'my$pass',
    database: 'mycloset'
});

const app = express();

app.engine('handlebars', engine({ 
//    defaultLayout: "main"
}));
app.set('view engine', 'handlebars');
app.use(express.static("static"));
app.use(express.static('public'));

console.log("test in app.js");
app.use('/outfitbuilder', require('./top.js'));

//load homepage
app.get('/', function (req, res) {
    res.render('homepage');
});

//load outfit builder
app.get('/outfitbuilder', function (req, res) {
    console.log("rendering outfitbuilder");
    res.render('outfitbuilder');
});

//load outfit editor
app.get('/outfitviewer', function (req, res) {
    res.render('outfitviewer');
});

//connect mysql
/*db.connect((err) => {
    if(err){
        throw err;
    }
    console.log('MySQL connected..');
});*/

//listen on port 3000
app.listen('3000', () => {
    console.log('Server started on port');
});