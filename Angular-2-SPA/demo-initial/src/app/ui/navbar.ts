import { Component } from '@angular/core'

@Component({
    selector: 'navbar',
    template: `
    <header class="app-bar row middle-xs">
        <span [routerLink]="['']" class="logo col-xs-10">
            Boring To Do List
        </span>
        <nav class="col-xs-2">
            <div class="row middle-xs between-xs">
                <span [routerLink]="['about']" class="link">About</span>
                <span class="link">signout</span>
            </div>
        </nav>
    </header>
    `,
    styles: [`
        .app-bar {
            height: 65px;
            padding: 5px 30px;
            background-color: #00BCD4;
            margin-right: 0;
            margin-left: 0;
        }
        .logo {
            color: white;
            font-size: 30px;
            font-weight: 300;
            cursor: pointer;
        }
        .link {
            color: white;
            font-size: 24px;
            font-weight: 400;
            cursor: pointer; 
        }
    `]
})
export class Navbar { }