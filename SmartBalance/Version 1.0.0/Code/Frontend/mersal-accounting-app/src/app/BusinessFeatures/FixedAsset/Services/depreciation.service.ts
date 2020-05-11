import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { Depreciation } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class DepreciationService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}Depreciations`;

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getDepreciationsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getDepreciationsByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllDepreciations(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getDepreciation(id: any): Observable<Depreciation> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Depreciation>(url);
  }
  addDepreciation(item: Depreciation): Observable<Depreciation> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  addDepreciationCollection(array: any[]) : Observable<any[]> {
    let url: string = `${this.controller}/add-collection`;
    return this.postData(url, array);
  }
  updateDepreciation(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteDepreciation(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
