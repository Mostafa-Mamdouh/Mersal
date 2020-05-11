import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { BankAccountChart } from '../Models/bank-account-chart.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class BankAccountChartService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}BankAccountCharts`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getBankAccountChartsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getBankAccountChartsByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllBankAccountCharts(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getBankAccountChart(id: any): Observable<BankAccountChart[]> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<BankAccountChart[]>(url);
  }
  getAccountCharts(bankId): Observable<any[]>{
    let url: string = `${this.controller}/get-account-charts/${bankId}`;
    return this.getData<any[]>(url)
  }
  addBankAccountChart(item: BankAccountChart): Observable<BankAccountChart> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  addBankAccountCharts(item: BankAccountChart[]): Observable<BankAccountChart[]> {
    let url: string = `${this.controller}/add-collection`;
    return this.postData(url, item);
  }
  updateBankAccountChart(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  updateBankAccountCharts(item: any): Observable<any> {
    let url: string = `${this.controller}/update-collection`;
    return this.postData(url, item);
  }
  deleteBankAccountChart(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
