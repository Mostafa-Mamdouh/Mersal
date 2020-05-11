import { Component, OnInit, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { BrandService } from '../../../../BusinessFeatures/Brand/Services/brand.service';


@Component({
    selector: 'drop-down-tree',
    templateUrl: './drop-down-tree.component.html',
    styleUrls: ['./drop-down-tree.component.scss'],
})
export class DropDownTreeComponent implements OnInit {

    @Input() data: any[];
    @Input() textField: any;
    @Input() childrenField: string;
    @Input() canEdit: boolean;
    @Input() value: any;
    @Output() valuechangedOutPutEvent: EventEmitter<any> = new EventEmitter();
    @Output() expandOutPutEvent: EventEmitter<any> = new EventEmitter();


    constructor(
        private brandService: BrandService
    ) { }

    ngOnInit(): void {

        //this.getBarndLookup();
        //throw new Error("Method not implemented.");
    }
    ngOnChanges(changes: SimpleChanges) {
        //debugger;
        if (this.value) {
            this.selectedKeys = this.value
        }
        else {
            this.selectedKeys = "";
        }
    }

    show: boolean = false;

    selectedKeys: string;

    public onToggle(): void {
        //debugger;
        this.show = !this.show;
    }

    public handleSelection(event: any): void {
        debugger;
        this.show = false;
        let id = event.id;
        if(event.dataItem.id){
            id = event.dataItem.id;
        }else{
            id = event.dataItem.assetId;
        }
        
        this.selectedKeys = event.dataItem.displyedName;
        this.valuechangedOutPutEvent.emit(id);
    }

    handleExpand(event) {
        this.expandOutPutEvent.emit(event);
    }
}
