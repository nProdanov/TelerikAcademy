import { Component } from '@angular/core';
import { AuthService } from './auth-service';

@Component({
  selector: 'daily-deals',
  template: `
  <div class="container">
    <nav class="navbar navbar-default">
      <div class="navbar-header">
        <a class="navbar-brand" routerLink="/dashboard"></a>
      </div>
      <ul class="nav navbar-nav">
        <li>
          <a routerLink="/deals" routerLinkActive="active">Deals</a>
        </li>
        <li>
          <a routerLink="/special" *ngIf="authService.loggedIn()" routerLinkActive="active">Private deals</a>
        </li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li>
          <a (click)="authService.login()" *ngIf="!authService.loggedIn()">Log in</a>
        </li>
        <li>
          <a (click)="authService.logout()" *ngIf="authService.loggedIn()">Log out</a>
        </li>
      </ul>
    </nav>
    <router-outlet></router-outlet>
  </div>
  `,
  styles: ['.navbar-right { margin-right: 0px !important}']
})
export class AppComponent {
  title = 'Daily deals';

  private authService: AuthService;

  constructor(authService: AuthService) {
    this.authService = authService;
  }
}
