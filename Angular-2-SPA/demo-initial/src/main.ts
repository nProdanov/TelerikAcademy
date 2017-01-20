import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { HttpModule } from '@angular/http'
import { BrowserModule } from '@angular/platform-browser'
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'
import { App, providers, routes } from './app'
import { MainContainer, NotesContrainer, AboutContainer } from './app/containers'
import { Navbar, NoteCard, NoteCreator, ColorPicker } from './app/ui'

@NgModule({
    declarations: [
        App,
        MainContainer,
        NotesContrainer,
        Navbar,
        NoteCard,
        NoteCreator,
        AboutContainer,
        ColorPicker
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routes
    ],
    providers,
    bootstrap: [App]
})
export class Main { }

platformBrowserDynamic().bootstrapModule(Main)