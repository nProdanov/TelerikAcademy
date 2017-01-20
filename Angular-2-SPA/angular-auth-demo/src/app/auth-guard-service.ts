import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

import { AuthService } from './auth-service';

@Injectable()
export class AuthGuard implements CanActivate {
    private auth: AuthService;
    private router: Router;

    constructor(auth: AuthService, router: Router) {
        this.auth = auth;
        this.router = router;
    }

    canActivate() {
        if (!this.auth.loggedIn()) {
            this.router.navigate(['']);
            return false;
        }

        return true;
    }
}