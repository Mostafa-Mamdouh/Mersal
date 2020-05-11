import { Injectable, OnInit, OnDestroy } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PaginationOptions } from '../Models/pagination-options.model';

@Injectable({
    providedIn: 'root'
})
export class PaginationService implements OnDestroy {

    private _paginationOptions: PaginationOptions;
    private readonly _key: string = 'pagination-options';

    constructor(
    ) {
        this.initializePaginationOptions();
    }
   

    private initializePaginationOptions() {
        //debugger;
        let savedPaginationOptionsString = localStorage.getItem(this._key);
        let savedPaginationOptions: PaginationOptions = null;

        if(savedPaginationOptionsString) {
            savedPaginationOptions = JSON.parse(savedPaginationOptionsString) as PaginationOptions;
        }
        else {
            this._paginationOptions = new PaginationOptions();
            this._paginationOptions.pageSize = 100;
            this._paginationOptions.pagenationSizeList = [
                {value: 5},
                {value: 10},
                {value: 20},
                {value: 50},
                {value: 100},
                {value: 150},
                {value: 200},
            ];
        }
    }
    getPaginationOptions(): PaginationOptions {
        //debugger;
        return this._paginationOptions;
    }
    setPaginationOptions(newSize: number) {
        this._paginationOptions.pageSize = newSize;
    }

    savePaginationOptions(): void {
        localStorage.setItem(this._key, JSON.stringify(this._paginationOptions));
    }

    ngOnDestroy(): void {
        debugger;
        this.savePaginationOptions();
    }
}