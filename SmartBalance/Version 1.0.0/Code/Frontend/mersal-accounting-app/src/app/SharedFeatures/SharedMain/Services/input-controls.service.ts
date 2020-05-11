import { Injectable, OnInit, OnDestroy } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PaginationOptions } from '../Models/pagination-options.model';
import { FormControl, FormGroup } from '@angular/forms';

@Injectable({
    providedIn: 'root'
})
export class InputControlService implements OnDestroy {

    clearControl(formGroup: FormControl, controlName: string) {
        debugger;
        formGroup.setValue(null);
      }

    ngOnDestroy(): void {
        debugger;
        //this.savePaginationOptions();
    }
}