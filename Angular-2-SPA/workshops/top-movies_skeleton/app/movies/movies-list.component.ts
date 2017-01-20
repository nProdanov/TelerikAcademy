import { Component, OnInit } from '@angular/core';
import { Movie, MovieFactory } from '../models/movie';
import { MoviesServices } from '../services/movies-services';

@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html',
    providers: [MoviesServices]
})
export class MoviesListComponent implements OnInit {
    public pageTitle: string;
    public services: MoviesServices;

    public movies: Movie[];

    public orderTypes: string[];
    public orderBys: string[];
    public orderType: string;
    public orderBy: string;
    public searchPattern: string;

    constructor(services: MoviesServices) {
        this.services = services;
        this.movies = [];
        this.orderTypes = ['asc', 'desc'];
        this.orderType = this.orderTypes[0];
        this.orderBys = ['title', 'year', 'rating'];
        this.orderBy = this.orderBys[0];
        this.searchPattern = '';
    }

    ngOnInit() {
        this.services.getMovies()
            .subscribe(res => {
                res = res.map((m: any) => MovieFactory.createMovie(m.Title, m.Poster, m.Year, m.imdbRating));
                this.movies = res;
            });
    }

    changeOrderType(value: string) {
        console.log(value);
        this.orderType = value;
    }

    changeOrderBy(value: string) {
        if (value === 'rating') {
            value = 'imdbRating';
        }

        this.orderBy = value;
    }

    search(value: string){
        this.searchPattern = value;
    }

}