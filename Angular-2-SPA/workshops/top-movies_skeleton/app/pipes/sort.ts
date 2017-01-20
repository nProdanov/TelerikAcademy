import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort'
})
export class SortPipe implements PipeTransform {
    transform(items: any[], sortBy: string, order: String) {
        let orderMultiplier = 1;
        if (order === 'desc') {
            orderMultiplier = -1;
        }
        if (sortBy === '') {
            sortBy = 'title'
        }

        items.sort((a, b) => {
            return (a[sortBy].toString().localeCompare(b[sortBy].toString())) * orderMultiplier;
        });

        return items;
    }
}