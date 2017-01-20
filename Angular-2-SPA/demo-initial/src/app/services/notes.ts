import { Injectable } from '@angular/core'
import { Api } from './api'

@Injectable()
export class NotesServices {
    private path: string = '/notes'

    private api: Api

    constructor(api: Api) {
        this.api = api
    }

    getNotes() {
        return this.api.get(this.path)
    }

    createNote(note) {
        return this.api.post(this.path, note)
    }

    completeNote(note) {
        return this.api.delete(`${this.path}/${note.id}`);
    }
}
