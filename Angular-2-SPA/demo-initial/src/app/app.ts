import { Component } from '@angular/core'

@Component({
    selector: 'app',
    template: `
    <div>
        <navbar></navbar>
        <router-outlet></router-outlet>
    </div>
    `
})
export class App { }