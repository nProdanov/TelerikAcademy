import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'search'
})
export class SearchPipe implements PipeTransform {
    transform(items: any[], pattern: string) {
        let regexPatt = new RegExp(pattern, 'gi',);
        items = items.filter(m => {
           return regexPatt.test(m.title.toString());
        });

        return items;
    }
}