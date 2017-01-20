import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { AuthHttp } from 'angular2-jwt';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { Deal } from './deal';

@Injectable()
export class DealService {
    private publicDealsUrl = 'http://localhost:3001/api/deals/public';
    private privateDealsurl = 'http://localhost:3001/api/deals/private';

    private http: Http;
    private authHttp: AuthHttp;

    constructor(http: Http, authHttp: AuthHttp) {
        this.http = http;
        this.authHttp = authHttp;
    }

    getPublicDeals(): Observable<Deal[]> {
        return this.http
            .get(this.publicDealsUrl)
            .map((res: Response) => res.json());
    }

    getPrivateDeals(): Observable<Deal[]> {
        return this.authHttp
            .get(this.privateDealsurl)
            .map((res: Response) => res.json());
    }
}