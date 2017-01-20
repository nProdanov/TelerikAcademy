/* globals module */

"use strict";

function solve() {
    const CONSTANTS = {
        OPT_NAME: 'Value'
    };
    const ERR_MSGS = {
        UNDEFINED: ' must not be an undefined',
        STRING: ' must be a string',
        NUM: ' must be a number'
    };
    const validator = {
        validateIfUndefined: function (val, name) {
            name = name || CONSTANTS.OPT_NAME;
            if (val === undefined) {
                throw new Error(name + ERR_MSGS.UNDEFINED);
            }
        },
        validateIfObject: function (val, name) {
            name = name || CONSTANTS.OPT_NAME;
            this.validateIfUndefined(val, name);

            if (typeof val !== 'object') {
                throw new Error(name + ERR_MSGS.OBJ);
            }
        },
        validateIfValidString: function (text, name) {
            name = name || CONSTANTS.OPT_NAME;
            this.validateIfUndefined(text, name);

            if (typeof text !== 'string') {
                throw new Error(name + ERR_MSGS.STRING);
            }
        },
        validateIfNumber(val, name) {
            name = name || CONSTANTS.OPT_NAME;
            this.validateIfUndefined(val, name);

            if (typeof val !== 'number') {
                throw new Error(name + ERR_MSGS.NUM);
            }
        },
        validateIfProduct: function (value, name) {
            name = name || CONSTANTS.OPT_NAME;
            this.validateIfObject(value, name);
            this.validateIfUndefined(value.productType, 'Prodcut type of product');
            this.validateIfUndefined(value.name, 'Name of the product');
            this.validateIfUndefined(value.price, 'Price of the product');
        }
    };

    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(value) {
            validator.validateIfValidString(value, 'Product type');
            this._productType = value;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            validator.validateIfValidString(value, 'Name of the product');
            this._name = value;
        }

        get price() {
            return this._price;
        }

        set price(value) {
            validator.validateIfNumber(value, 'Price');
            this._price = value;
        }
    }

    class ShoppingCart {
        constructor() {
            this._products = [];
        }

        get products() {
            return this._products;
        }

        set products(value) {
            this._products = value;
        }

        add(product) {
            validator.validateIfProduct(product, 'Product to add');

            this._products.push(product);
            return this;
        }

        remove(productToRemove) {
            validator.validateIfProduct(productToRemove, 'Product to remove');
            if (this._products.length === 0) {
                throw new Error('No products in cart');
            }

            let productToRemoveInd = this._products.indexOf(productToRemove);
            if (productToRemoveInd < 0) {
                throw new Error('No such a product in the cart');
            }
            else {
                this._products.splice(productToRemoveInd, 1);
            }
        }

        showCost() {
            let cost = 0;
            this._products.forEach(prod => cost += prod.price);

            return cost;
        }

        showProductTypes() {
            let productTypesToShow = this._products
                .map(prod => prod.productType)
                .filter((value, index, self) => self.indexOf(value) === index)
                .sort((first, second) => first.localeCompare(second));
            return productTypesToShow;
        }

        getInfo() {
            let filteredProdNames = this._products
                .map(prod => prod.name)
                .filter((value, index, self) => self.indexOf(value) === index);

            let productsToShow = [];

            for (let i = 0, len = filteredProdNames.length; i < len; i += 1) {
                let currName = filteredProdNames[i];
                let currProductToShow = {
                    name: currName,
                    totalPrice: 0,
                    quantity: 0
                };

                for (let j = 0, prLen = this._products.length; j < prLen; j += 1) {
                    let currProduct = this._products[j];
                    if (currName === currProduct.name) {
                        currProductToShow.totalPrice += currProduct.totalPrice;
                        currProductToShow.quantity += 1;
                    }
                }

                productsToShow.push(currProductToShow);
            }

            return {
                totalPrice: this.showCost(),
                products: productsToShow
            };
        }
    }

    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;