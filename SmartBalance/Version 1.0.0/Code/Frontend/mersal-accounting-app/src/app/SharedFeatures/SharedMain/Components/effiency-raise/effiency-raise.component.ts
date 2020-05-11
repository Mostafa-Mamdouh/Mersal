import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { EditorMode } from '../../Models/editor-mode.enum';
import { EffiencyRaise } from '../../Models/effiency-raise.model';
import * as $ from 'jquery';


@Component({
    selector: 'app-add-effiencyraise',
    templateUrl: './effiency-raise.component.html',
    styleUrls: ['./effiency-raise.component.scss'],
})
export class EffiencyRaiseComponent implements OnInit {

    @Output() effiencyRaiseFormValueChanged: EventEmitter<any> = new EventEmitter();
    effiencyRaiseModel : EffiencyRaise = new EffiencyRaise();
    effiencyRaiseFormGroup: FormGroup;
    isSubmited: boolean = false;
    
    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
    };
    editorMode: EditorMode = EditorMode.add;
    editorModeEnum = EditorMode;
    constructor(
        private fb: FormBuilder,
        private notification: NotificationService,
    ) { }

    ngOnInit() {
        this.buildForm();
    }
    canEdit(): boolean {
        return this.editorMode != EditorMode.detail;
      }
    buildForm(): void {
        debugger;
        this.effiencyRaiseFormGroup = this.fb.group({
            raiseAmount: [null, [Validators.required]],
            raiseDate: [new Date(), [Validators.required]],
        });
    }
    AddEffiencyRaise(): void {
        if (this.effiencyRaiseFormGroup.valid) {
            debugger
            this.effiencyRaiseModel.raiseAmount = this.effiencyRaiseFormGroup.controls["raiseAmount"].value;
            this.effiencyRaiseModel.raiseDate = this.effiencyRaiseFormGroup.controls["raiseDate"].value;

            this.effiencyRaiseFormValueChanged.emit(this.effiencyRaiseModel);
            this.Close();
        }
        else {
            this.notification.showDataMissingError();
        }
    }
    Close() {
        $("#addEffienceRaise").click();
    }
    fireAddEvent() {
        this.AddEffiencyRaise();
    }

}
