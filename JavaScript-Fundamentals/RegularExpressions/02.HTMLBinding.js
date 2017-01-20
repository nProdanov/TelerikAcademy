'use strict';
function solve(args) {
    let data = args[0];
    let html = args[1];

    data = JSON.parse(data);


    String.prototype.blind = function (data) {

        let pat = new RegExp('data-bind-([a-z]+)="([a-z]+)"', 'g');
        let match = pat.exec(this);

        let result = '';
        result += html.split('><\/')[0];
        let first = html.split('><\/')[0];
        let second = html.split('><\/')[1];

        let content = '';

        while (match) {
            if (match[1] === 'content') {
                content = data[match[2]];
            }
            else {
                result = result + ' ' + match[1] + '="' + data[match[2]] + '"';
            }
            match = pat.exec(this);
        }
        result = result + '>' + content + '<\/' + second;
        return result;

    };

    return html.blind(data);


}
console.log( solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
]));