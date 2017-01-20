'use strict';

const express = require('express');
const app = express();
const cors = require('cors');
const jwt = require('express-jwt')
app.use(cors());

const authCheck = jwt({
    secret: new Buffer('gzzhmNCuHPcTXapClcREN7A5L8JvxJ2-xL9RTcAD_tIv7VoLr55e6_4qK9ms78Bk', 'base64'),
    audience: 'wFe7CwezBHRXTHI7ZTCK3Jp7x4PWLqrK'
});

app.get('/api/deals/public', (req, res) => {
    let deals = [
        {
            id: 1234,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        },
        {
            id: 1235,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        },
        {
            id: 1236,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        }
    ];

    res.json(deals);
});

app.get('/api/deals/private', authCheck, (req, res) => {
    let deals = [
        {
            id: 1239,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        },
        {
            id: 1238,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        },
        {
            id: 1237,
            name: 'Name of Product',
            description: 'Description of Product',
            originalPrice: 19.99, // Original price of product
            salePrice: 9.99 // Sale price of product
        }
    ];

    res.json(deals);
});

app.listen(3001);

console.log('Serving on localhost:3001');