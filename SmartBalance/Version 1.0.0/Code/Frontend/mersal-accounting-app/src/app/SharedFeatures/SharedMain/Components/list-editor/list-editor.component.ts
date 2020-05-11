//list-editor.component
import { Component, Input, Output, OnInit, EventEmitter, OnChanges, ViewChild, ElementRef, SimpleChange } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { NameValue } from '../../Models/name-value.model';

@Component({
    selector: 'list-editor',
    styleUrls: ['./list-editor.component.scss'],
    templateUrl: './list-editor.component.html'
})
export class ListEditorComponent implements OnInit {

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private notificationService: NotificationService,
        private translateService: TranslateService,
    ) { }

    ngOnChanges(simple: SimpleChange) {

    }

    ngOnInit(): void {

    }

    sourceClicked(item: NameValue) {
        if (item) {
            item.selected = !item.selected;
        }
    }

    destClicked(item: NameValue) {
        //debugger;
        if (item) {
            item.selected = !item.selected;
        }
    }

    moveSelectedToDest() {
        //debugger;
        if(!this.canEdit) return;

        if (this.destList) {
            this.destList.forEach(item => item.selected = false);
        }

        if (this.sourceList) {
            let thereChange: boolean = false;
            let selectedItems = this.sourceList.filter(x => x.selected == true);

            if (selectedItems && selectedItems.length > 0) {
                selectedItems.forEach(item => {
                    let newItem = new NameValue();
                    newItem.selected = true;
                    newItem.value = item.value;
                    newItem.name = item.name;

                    if (!this.destList) {
                        this.destList = [];
                    }                    
                    this.destList.push(newItem);
                    thereChange = true;
                });

                for (let i = 0; i < selectedItems.length; i++) {
                    let item = selectedItems[i];
                    let existItemIndex: number = this.sourceList.findIndex(x => x.value == item.value && x.name == item.name);

                    if (existItemIndex != -1) {
                        this.sourceList.splice(existItemIndex, 1);
                    }
                }
            }

            //debugger;
            if (thereChange) {
                this.sourceListChanged.emit(this.sourceList);
                this.destListChanged.emit(this.destList);
            }
        }
    }
    moveAllToDest() {
        //debugger;
        if(!this.canEdit) return;

        if (this.destList) {
            this.destList.forEach(item => item.selected = false);
        }

        if (this.sourceList) {
            let thereChange: boolean = false;

            this.sourceList.forEach(item => {
                let newItem = new NameValue();
                newItem.selected = true;
                newItem.value = item.value;
                newItem.name = item.name;

                if (!this.destList) {
                    this.destList = [];
                }
                this.destList.push(newItem);
                thereChange = true;
            });

            this.sourceList = [];

            //debugger;
            if (thereChange) {
                this.sourceListChanged.emit(this.sourceList);
                this.destListChanged.emit(this.destList);
            }
        }
    }
    moveSelectedToSourcet() {
        //debugger;
        if(!this.canEdit) return;

        if (this.sourceList) {
            this.sourceList.forEach(item => item.selected = false);
        }

        if (this.destList) {
            let thereChange: boolean = false;
            let selectedItems = this.destList.filter(x => x.selected == true);

            if (selectedItems && selectedItems.length > 0) {
                selectedItems.forEach(item => {
                    let newItem = new NameValue();
                    newItem.selected = true;
                    newItem.value = item.value;
                    newItem.name = item.name;

                    if (!this.sourceList) {
                        this.sourceList = [];
                    }
                    this.sourceList.push(newItem);
                    thereChange = true;
                });

                for (let i = 0; i < selectedItems.length; i++) {
                    let item = selectedItems[i];
                    let existItemIndex: number = this.destList.findIndex(x => x.value == item.value && x.name == item.name);

                    if (existItemIndex != -1) {
                        this.destList.splice(existItemIndex, 1);
                    }
                }
            }

            //debugger;
            if (thereChange) {
                this.sourceListChanged.emit(this.sourceList);
                this.destListChanged.emit(this.destList);
            }
        }
    }
    moveAllToSource() {
        //debugger;
        if(!this.canEdit) return;

        if (this.sourceList) {
            this.sourceList.forEach(item => item.selected = false);
        }

        if (this.destList) {
            let thereChange: boolean = false;

            this.destList.forEach(item => {
                let newItem = new NameValue();
                newItem.selected = true;
                newItem.value = item.value;
                newItem.name = item.name;

                if (!this.sourceList) {
                    this.sourceList = [];
                }
                this.sourceList.push(newItem);
                thereChange = true;
            });

            this.destList = [];

            //debugger;
            if (thereChange) {
                this.sourceListChanged.emit(this.sourceList);
                this.destListChanged.emit(this.destList);
            }
        }
    }


    unselectAllSourceItems() {
        if(this.sourceList) {
            this.sourceList.forEach(item => item.selected = false);
        }
        this.sourceSearchText = null;
    }

    unselectAllDestItems() {
        if(this.destList) {
            this.destList.forEach(item => item.selected = false);
        }
        this.distSearchText = null;
    }

    isAnySourceItemSelected(): boolean {
        let result = false;

        if (this.sourceList) {
            for (let i=0; i<this.sourceList.length; i++) {
                if(this.sourceList[i].selected) {
                    result = true;
                    break;                    
                }
            }           
        }

        return result;
    }

    isAnyDestItemSelected(): boolean {
        let result = false;

        if (this.destList) {
            for (let i=0; i<this.destList.length; i++) {
                if(this.destList[i].selected) {
                    result = true;
                    break;
                }
            }           
        }

        return result;
    }


    @Input() sourceList: NameValue[];
    @Input() destList: NameValue[];
    @Input() canEdit: boolean = true;
    @Output() sourceListChanged: EventEmitter<NameValue | NameValue[]> = new EventEmitter<NameValue | NameValue[]>();
    @Output() destListChanged: EventEmitter<NameValue | NameValue[]> = new EventEmitter<NameValue | NameValue[]>();

    PageLoading: boolean;
    private editorForm: FormGroup;
    private editorMode: EditorMode = EditorMode.add;
    private editorModeEnum = EditorMode;
    private isProccessing: boolean;
    sourceSearchText: any;
    distSearchText: any;
}