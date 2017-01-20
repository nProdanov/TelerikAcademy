function solve() {
    return function (selector) {
        debugger;
        var template = 
        '<div class="events-calendar">' +
            '<h2 class="header">' +
                'Appointments for <span class="month">{{this.month}}</span> <span class="year">{{this.year}}</span>' +
            '</h2>' +
            '{{#each this.days}}' +
            '<div class="col-date">' +
                '<div class="date">{{this.day}}</div>' +
                '<div class="events">' +
                '{{#each this.events}}' +
                    '<div class="event {{this.importance}}", {{#if this.comment}}title="{{this.comment}}"{{/if}}>' +
                        '<div class="title">{{#if this.title}}{{this.title}}{{else}}Free slot{{/if}}</div>' +
                        '{{#if this.time}}<span class="time">at: {{this.time}}</span>{{/if}}' +
                    '</div>' +
                    '{{/each}}' +
                '</div>' +
            '</div>' +
            '{{/each}}' +
        '</div>';		
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;