import { Injectable } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

declare var Auth0Lock: any;

@Injectable()
export class AuthService {
    lock = new Auth0Lock('wFe7CwezBHRXTHI7ZTCK3Jp7x4PWLqrK', 'toolsforteams.eu.auth0.com');


    private router: Router;
    private jwt: JwtHelper;

    constructor(router: Router, jwt: JwtHelper) {
        this.router = router;
        this.jwt = jwt;

        this.lock.on('authenticated', (authResult: any) => {
            localStorage.setItem('id_token', authResult.idToken);

            this.lock.getProfile(authResult.idToken, (error: any, profile: any) => {
                if (error) {
                    console.log(error);
                }

                localStorage.setItem('profile', JSON.stringify(profile));
            });

            this.lock.hide();
        });
    }

    login() {
        console.log('HERE');
        this.lock.show();
    }

    logout() {
        console.log('here');
        localStorage.removeItem('profile');
        localStorage.removeItem('id_token');

        this.router.navigateByUrl('/deals');
    }

    loggedIn() {
        return !this.jwt.isTokenExpired(localStorage.getItem('id_token'));
    }
}