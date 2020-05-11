//bank.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { Bank, BankLight } from '../Models/bank.model';
//import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class BankService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Banks`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getBanksLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getBanksByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllBanks(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getBank(id: any): Observable<Bank> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Bank>(url);
  }
  addBank(item: Bank): Observable<Bank> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateBank(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteBank(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
