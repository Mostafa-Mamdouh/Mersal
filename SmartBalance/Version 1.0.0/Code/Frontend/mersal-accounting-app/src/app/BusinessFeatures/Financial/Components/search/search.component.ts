import {FinancialService} from '../../Services/financial.service';
import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {Router} from '@angular/router';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {NotificationService} from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { BranchLookup } from '../../Models/branch-lookup.model';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Search } from '../../Models/search.model';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  providers: [FinancialService]
})
export class SearchComponent implements OnInit {
  public BranchesDropDownData:Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  searchForm: FormGroup;
  @Output() searchChanged: EventEmitter<Search> = new EventEmitter();
  Branches: BranchLookup[] = [];
  bsDatePickerValue: Date;
  outputSearch: Search =new Search();

  constructor(
    public router: Router,
    private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notification: NotificationService) {
  }

  ngOnInit() {
    this.buildForms();
    this.getBranchLookup();
    this.bsDatePickerValue = new Date();
  }
  
  getBranchLookup() {
    this.ReceiptsServ.getBranchLookup()
      .subscribe(
        res =>
        {
          var array=new Array<any>();
          res.forEach(function(item){
            var record= new KendoDropDown();
            record.text=item.code+" - "+item.name;
            record.value=item.id;
            array.push(record);
          });
          this.BranchesDropDownData=array;
        },
        error =>
        {
          error;
          this.notification.showOperationFailed();
        }
        
      );
  }

  fireSearchChanged(): void {
    this.searchChanged.emit(this.outputSearch);
  }
  
  Search() {
    if(this.searchForm.controls['DateFrom'].value>this.searchForm.controls['DateTo'].value){
      this.notification.showTranslateError('financial.dateRang');
      return;
    }
    else if(this.searchForm.controls['AmountFrom'].value>this.searchForm.controls['AmountTo'].value){
      this.notification.showTranslateError('financial.amountRang');
      return;
     }
     else if(!(this.searchForm.controls['AmountFrom'].value>0 )&& this.searchForm.controls['AmountTo'].value>0){
      this.notification.showTranslateError('financial.amountRang');
      return;
     }
    else{
      if(this.searchForm.valid){
        this.outputSearch=this.searchForm.value;
        this.fireSearchChanged(); 
      }
     
    }
  }

  buildForms(): void {
    this.searchForm = this.fb.group({
      Branch: [null],
      DateTo: [new Date(),[Validators.required]],
      DateFrom: [new Date(new Date().setMonth(new Date().getMonth() - 1)),[Validators.required]],
      AmountFrom: [null],
      AmountTo: [null],
    });
  }

}
