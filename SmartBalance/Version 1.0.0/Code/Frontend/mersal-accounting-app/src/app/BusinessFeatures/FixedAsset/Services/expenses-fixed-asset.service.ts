import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { ExpenseAsset, FixedAssetLight } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class ExpensesAssetService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Expenses`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getExpenseAssesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getExpenseAssesByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllExpenseAsses(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getExpenseAsse(id: any): Observable<ExpenseAsset> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<ExpenseAsset>(url);
  }
  addExpenseAsse(item: ExpenseAsset): Observable<ExpenseAsset> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateExpenseAsset(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteExpenseAsse(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
