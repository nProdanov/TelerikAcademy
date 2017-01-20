import { Injectable } from '@angular/core'
import { Http, Headers, Response } from '@angular/http'
import { Observable } from 'rxjs/Observable'

@Injectable()
export class Api {
    private headers: Headers = new Headers({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    })

    private http: Http
    private baseUrl: string = 'http://localhost:3500'

    constructor(http: Http) {
        this.http = http;
    }

    private checkForErrors(resp: Response) {
        if (resp.status >= 200 && resp.status < 300) {
            return resp
        } else {
            let error = new Error(resp.statusText)
            error['response'] = resp
            console.log(error)
            throw error
        }
    }

    private getJson(resp: Response) {
        return resp.json()
    }

    get(path: string): Observable<any> {
        return this.http.get(
            `${this.baseUrl}${path}`,
            { headers: this.headers })
            .map(this.checkForErrors)
            .catch(err => Observable.throw(err))
            .map(this.getJson)
    }

    post(path: string, data): Observable<any> {
        return this.http.post(
            `${this.baseUrl}${path}`,
            JSON.stringify(data),
            { headers: this.headers })
            .map(this.checkForErrors)
            .catch(err => Observable.throw(err))
            .map(this.getJson)
    }

    delete(path: string): Observable<any> {
        return this.http.delete(
            `${this.baseUrl}${path}`,
            { headers: this.headers })
            .map(this.checkForErrors)
            .catch(err => Observable.throw(err))
            .map(this.getJson)
    }
}