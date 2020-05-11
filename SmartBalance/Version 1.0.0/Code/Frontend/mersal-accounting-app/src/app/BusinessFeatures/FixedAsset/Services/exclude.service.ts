import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Exclude } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class ExcludeService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Excludes`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getExcludesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getExcludesByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllExcludes(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getExclude(id: any): Observable<Exclude> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Exclude>(url);
  }
  addExclude(item: Exclude): Observable<Exclude> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  addExcludeCollection(array: any[]) : Observable<any[]> {
    let url: string = `${this.controller}/add-collection`;
    return this.postData(url, array);
  }
  updateExclude(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteExclude(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
