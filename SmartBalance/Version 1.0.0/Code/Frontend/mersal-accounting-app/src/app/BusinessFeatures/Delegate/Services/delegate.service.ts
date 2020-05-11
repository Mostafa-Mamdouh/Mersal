//Delegate.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { Delegate } from '../Models/delegate.model';
import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class DelegateService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}DelegateMans`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getDelegatesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getDelegatesByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllDelegates(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getDelegate(id: any): Observable<Delegate> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Delegate>(url);
  }
  addDelegate(item: Delegate): Observable<Delegate> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateDelegate(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteDelegate(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
