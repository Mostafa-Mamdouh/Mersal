import { Component, OnInit, ViewChild } from '@angular/core';
import {NotificationService} from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { DashboardService } from '../../Services/dashboard.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { LanguageService } from 'src/app/SharedFeatures/SharedMain/Services/language.service';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit { 
 
  constructor(
    private notification: NotificationService,
    private dashboardService: DashboardService,
    private messages: MessageService,
    private languageService: LanguageService,
    private translationService: TranslateService,

   
  ) { }

  ngOnInit() { 
    
    this.lang = this.languageService.getSavedLang();
    this.getLineAndColumnCharts();
  }
  public getLineAndColumnCharts(){
    if(this.lang=='ar')
     {

      this.PaymentMovementChartPosition="right";
      //this.categories= ['ينابر', 'فبراير', 'مارس', 'ابريل', 'مايو', 'يونيو', 'يوليو' ,'اغسطس' , 'سبتمبر' , 'اكتوبر' , 'نوفمبر' , 'ديسمبر'];
      this.categories= ['1', '2', '3', '4', '5', '6', '7' ,'8' , '9' , '10' , '11' , '12'];
      this.rtl = true;
      this.messages.notify(this.rtl);
     }
     else{
      this.PaymentMovementChartPosition="left";
      //this.categories= ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul' ,'Aug' , 'Sep' , 'Oct' , 'Nov' , 'Dec'];
      this.categories= ['1', '2', '3', '4', '5', '6', '7' ,'8' , '9' , '10' , '11' , '12'];
      this.rtl = false;
      this.messages.notify(this.rtl);

     }  
    this.dashboardService.getPaymentMovementsChart()
    .subscribe(res => {
     this.PaymentMovementsChart=res.collection;
     this.PaymentMovementsChart.forEach(childObj=> {
       var Movement : string=childObj.movementName.replace(/\s/g, "");
      var lineChartObj:any = {
        name: this.translationService.instant(this.translationService.instant("dashboard."+Movement+"")),    
        data: [childObj.january, childObj.february, childObj.march, childObj.april, childObj.may, childObj.june, childObj.july,childObj.august,childObj.september,childObj.october,childObj.november,childObj.december]
     }
      this.lineChartseries.push(lineChartObj)

   })
   console.log(this.lineChartseries)

    },
      (error) => {
        this.notification.showOperationFailed();
      }, 
      () => {
        this.lineChartseriesDataRetrived = true;
      });


      this.dashboardService.getPaymentAndReceiptChart()
      .subscribe(res => {
       this.PaymentAndReceiptChart=res.collection;
       this.PaymentAndReceiptChart.forEach(childObj=> {
         var Movement : string=childObj.movementName.replace(/\s/g, "");
        var columnChartObj:any = {
          name: this.translationService.instant(this.translationService.instant("dashboard."+Movement+"")),    
          data: [childObj.january, childObj.february, childObj.march, childObj.april, childObj.may, childObj.june, childObj.july,childObj.august,childObj.september,childObj.october,childObj.november,childObj.december]
       }
        this.columnChartseries.push(columnChartObj)
  
     })
     console.log(this.lineChartseries)
  
      },
        (error) => {
          this.notification.showOperationFailed();
        },
        () => {
          this.columnChartseriesDataRetrived = true;
        })
  }

  public labelContent(e: any): string {
    return e.category;
  }



  public data: any[] = [{
    kind: 'Hydroelectric', share: 0.175
  }, {
    kind: 'Nuclear', share: 0.238
  }, {
    kind: 'Coal', share: 0.118
  }, {
    kind: 'Solar', share: 0.052
  }, {
    kind: 'Wind', share: 0.225
  }, {
    kind: 'Other', share: 0.192
  }];

  public pieData: any = [
    { category: 'Eaten', value: 0.42 },
    { category: 'Not eaten', value: 0.58 }
  ];

  public categories: string[] ;
  PaymentMovementsChart:any [] ;
  PaymentAndReceiptChart:any [] ;

  lineChartseries: number[]=new Array();
  lineChartseriesDataRetrived: boolean;
  columnChartseries: number[]=new Array();
  columnChartseriesDataRetrived: boolean;

  public isVisible = true;
  private rtl = false;
  public lang :string;
  public PaymentMovementChartPosition:string;
  public model = [{
    stat: 'Impressions ',
    count: 434823,
    color: '#0e5a7e'
  }, {
    stat: 'Clicks',
    count: 356854,
    color: '#166f99'
  }, {
    stat: 'Unique Visitors',
    count: 280022,
    color: '#2185b4'
  }, {
    stat: 'Downloads',
    count: 190374,
    color: '#319fd2'
  }, {
    stat: 'Purchases',
    count: 120392,
    color: '#3eaee2'
  }];





  public weatherData = [
    { month: "January", min: 5, max: 11 },
    { month: "February", min: 5, max: 13 },
    { month: "March", min: 7, max: 15 },
    { month: "April", min: 10, max: 19 },
    { month: "May", min: 13, max: 23 },
    { month: "June", min: 17, max: 28 },
    { month: "July", min: 20, max: 30 },
    { month: "August", min: 20, max: 30 },
    { month: "September", min: 17, max: 26 },
    { month: "October", min: 13, max: 22 },
    { month: "November", min: 9, max: 16 },
    { month: "December", min: 6, max: 13 }
  ];

  public labelContentFrom(e: any): string {
      return `${ e.value.from } °C`;
  }

  public labelContentTo(e: any): string {
      return `${ e.value.to } °C`;
  }

  

}
