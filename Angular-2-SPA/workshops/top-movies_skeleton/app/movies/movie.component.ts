import { Component, Input } from '@angular/core';
import { Movie } from '../models/movie';

@Component({
    selector: 'movie',
    templateUrl: './movie.component.html',
    styles: [`
        .poster-img{
            height: 100px;    
        }
    `]
})
export class MovieComponent {
    @Input() movieData: Movie = {
        title: '',
        poster: '',
        year: '',
        imdbRating: ''
    }

}
