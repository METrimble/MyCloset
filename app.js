//reference used: https://www.youtube.com/watch?v=EN6Dx22cPRI&ab_channel=TraversyMedia

const express = require('express');
const mysql = require('mysql2'); //update avoids error relating to connection
const { engine } = require('express-handlebars');

//Create Connection to mysql
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'my$pass',
    database: 'MyCloset'
});

const app = express();

app.engine('handlebars', engine({ 
    defaultLayout: "main"
}));
app.set('view engine', 'handlebars');
app.set("views", "./views");

app.use(express.static('public'));

app.get('/', function (req, res) {
    res.render('test');
});

db.connect((err) => {
    if(err){
        throw err;
    }
    console.log('MySQL connected..');
});

app.listen('3000', () => {
    console.log('Server started on port');
});