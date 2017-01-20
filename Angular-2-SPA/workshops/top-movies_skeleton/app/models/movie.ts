import { Injectable } from '@angular/core';

export class Movie {
    public title: string;
    public poster: string;
    public year: string;
    public imdbRating: string;

    constructor(title: string, poster: string, year: string, imdbRating: string) {
        this.title = title;
        this.poster = poster;
        this.year = year;
        this.imdbRating = imdbRating;
    }
}

@Injectable()
export class MovieFactory {
    public static createMovie(title: string, poster: string, year: string, imdbRating: string) {
        return new Movie(title, poster, year, imdbRating);
    }
}


