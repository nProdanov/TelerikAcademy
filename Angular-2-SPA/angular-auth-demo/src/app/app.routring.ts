import { Routes, RouterModule, CanActivate } from '@angular/router';

import { AuthGuard } from './auth-guard-service';

import { PublicDealsComponent } from './public-deals.component';
import { PrivateDealsComponent } from './private-deals.component';

import { ModuleWithProviders } from '@angular/core'

const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/deals',
        pathMatch: 'full'
    },
    {
        path: 'deals',
        component: PublicDealsComponent
    },
    {
        path: 'special',
        component: PrivateDealsComponent,
        canActivate: [AuthGuard]
    }
];

export const routing = RouterModule.forRoot(appRoutes);
export const routersComponents = [PublicDealsComponent, PrivateDealsComponent];
