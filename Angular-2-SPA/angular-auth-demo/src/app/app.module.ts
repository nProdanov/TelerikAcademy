import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AUTH_PROVIDERS, JwtHelper } from 'angular2-jwt';

import { AppComponent } from './app.component';
import { routing, routersComponents } from './app.routring';

import { DealService } from './deal-service';
import { AuthService } from './auth-service';
import { AuthGuard } from './auth-guard-service';

@NgModule({
  declarations: [
    AppComponent,
    routersComponents
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    DealService,
    AUTH_PROVIDERS,
    AuthGuard,
    AuthService,
    JwtHelper
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
