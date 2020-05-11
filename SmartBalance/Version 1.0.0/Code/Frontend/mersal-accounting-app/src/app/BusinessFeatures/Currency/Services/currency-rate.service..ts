// //bank.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { CurrencyRate } from '../Models/currency-rate.model';
// import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class CurrencyRateService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}CurrencyRates`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getCurrencysLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getCurrencyByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllCurrencys(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getCurrency(id: any): Observable<CurrencyRate> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<CurrencyRate>(url);
  }
  addCurrency(item: CurrencyRate): Observable<CurrencyRate> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateCurrency(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteCurrency(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
