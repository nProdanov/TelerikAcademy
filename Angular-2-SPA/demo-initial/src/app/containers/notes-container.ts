import { Component, OnInit } from '@angular/core'
import { NotesServices } from '../services/notes'

@Component({
    selector: 'notes-container',
    template: `
    <div class="row center-xs notes">
        <div class="col-xs-6 creator">
            <note-creator (noteCreated)="createNote($event)"></note-creator>
        </div>
        <div class="notes col-xs-8">
        <div class="row between-xs">
            <note-card
                class="col-xs-4"
                [notedata]="note"
                *ngFor="let note of notes"
                (noteCardRemove)="removeNoteCard(note)"
            >
            </note-card>
        </div>
        </div>
    </div>
    `,
    styles: [`
    .notes {
        padding-top: 50px;
    }
    .creator {
        margin-bottom: 40px; 
    }
    `]
})
export class NotesContrainer implements OnInit {
    notes = []

    private notesService: NotesServices

    constructor(notesService: NotesServices) {
        this.notesService = notesService
    }

    ngOnInit() {
        this.notesService
            .getNotes()
            .subscribe(notes => {
                this.notes = notes.data
            })
    }

    createNote(note) {
        this.notesService
            .createNote(note)
            .subscribe(resNote => {
                this.notes.push(resNote)
            })
    }

    removeNoteCard(note) {
        this.notesService
            .completeNote(note)
            .subscribe(resNote => {
                let index = this.notes.findIndex(n => n.id === resNote.id)

                this.notes.splice(index, 1)
            })
    }
}