import { RouterModule } from '@angular/router'
import { ModuleWithProviders } from '@angular/core'
import { MainContainer, AboutContainer } from './containers'

export const routes: ModuleWithProviders
    = RouterModule.forRoot([
        {
            path: '',
            component: MainContainer
        },
        {
            path: 'about',
            component: AboutContainer
        },
        {
            path: '**',
            redirectTo: ''
        },

    ])