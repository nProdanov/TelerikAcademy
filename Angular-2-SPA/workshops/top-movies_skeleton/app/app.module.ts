import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { MoviesListComponent, MovieComponent } from './movies';

import { SortPipe, SearchPipe } from './pipes'

@NgModule({
    imports: [HttpModule, BrowserModule],
    declarations: [AppComponent, MoviesListComponent, MovieComponent, SortPipe, SearchPipe],
    bootstrap: [AppComponent]
})
export class AppModule { }
