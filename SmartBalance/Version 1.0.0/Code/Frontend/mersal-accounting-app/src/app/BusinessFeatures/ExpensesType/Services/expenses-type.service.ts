import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { ExpensesType, ExpensesTypeLight } from '../Models/expenses-type.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class ExpensesTypeService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}ExpensesTypes`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getExpensesTypesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getExpensesTypesByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllExpensesTypes(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getExpensesType(id: any): Observable<ExpensesType> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<ExpensesType>(url);
  }
  addExpensesType(item: ExpensesType): Observable<ExpensesType> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateExpensesType(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteExpensesType(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
