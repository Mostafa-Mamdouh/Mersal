//safe.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Safe, SafeAccountChartList } from '../Models/safe.model';
import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class SafeService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Safes`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getSafesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }


   getSafesByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllSafes(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getSafe(id: any): Observable<Safe> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Safe>(url);
  }

  getAccountcharts(safeId: any, currencyId: any): Observable<any> {
    let url: string = `${this.controller}/get-accountcharts/${safeId}/${currencyId}`;
    return this.getData<any>(url);
  }

  addSafe(item: Safe): Observable<Safe> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateSafe(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteSafe(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
  
  getSafeAccountcharts(safeId: number): Observable<SafeAccountChartList> {
    let url: string = `${this.controller}/get-safe-Accountcharts/${safeId}`;
    return this.getData(url);
  }
  updateSafeAccountcharts(item: SafeAccountChartList): Observable<SafeAccountChartList> {
    let url: string = `${this.controller}/update-safe-Accountcharts`;
    return this.postData(url, item);
  }

}
