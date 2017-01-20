import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MoviesServices {
    private http: Http;
    constructor(http: Http) {
        this.http = http;
    }

    getMovies(): Observable<any> {
        return this.http.get('../data/movies.json')
            .map((res: Response) => res.json());
    }
}
