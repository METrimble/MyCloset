//reference used: https://www.youtube.com/watch?v=EN6Dx22cPRI&ab_channel=TraversyMedia

const express = require('express');
const mysql = require('mysql2');

//Create Connection to mysql
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'my$pass',
    database: 'MyCloset'
});

db.connect((err) => {
    if(err){
        throw err;
    }
    console.log('MySQL connected..');
});

const app = express();

app.listen('3000', () => {
    console.log('Server started on port');
});