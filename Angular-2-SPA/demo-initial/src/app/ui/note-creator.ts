import {
    Component,
    Output,
    EventEmitter
} from '@angular/core'

@Component({
    selector: 'note-creator',
    template: `
    <div class="note-creator shadow-2">
        <form class="row" (submit)="createNote()">
        <input
            type="text"
            [(ngModel)]="newNote.title"
            name="newNoteTitle"
            placeholder="Title"
            class="col-xs-10 title"
        >
        <input
            type="text"
            [(ngModel)]="newNote.value"
            name="newNoteValue"
            placeholder="Take a note..."
            class="col-xs-10"
        >
        <div class="actions col-xs-12 row between-xs">
            <button
            type="submit"
            class="btn-light"
            >
            Done
            </button>
        </div>
        <color-picker (colorPicked)="pickColor($event)"></color-picker>
        </form>
    </div>
    `,
    styles: [`
    .note-creator {
        padding: 20px;
        background-color: white;
        border-radius: 3px;
    }
    .title {
        font-weight: bold;
        color: rgba(0,0,0,0.8);
    }
    .full {
        height: 100px;
    }
    `]
})
export class NoteCreator {
    newNote = {
        title: '',
        value: '',
        color: 'white'
    }

    @Output() noteCreated = new EventEmitter()

    pickColor(color) {
        this.newNote.color = color
    }

    createNote() {
        const {title, value, color} = this.newNote

        if (title && value) {
            this.noteCreated.next({ title, value, color })

            this.newNote.title = ''
            this.newNote.value = ''
            this.newNote.color = 'white'
        }
    }
}