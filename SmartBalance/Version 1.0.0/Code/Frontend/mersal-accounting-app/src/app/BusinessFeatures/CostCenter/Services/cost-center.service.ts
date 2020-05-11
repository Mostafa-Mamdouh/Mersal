import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { CostCenter } from '../Models/cost-center.model';
import {PostSearch} from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class CostCenterService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}CostCenters`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }


  getCostCentersLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getEmployeesCostCentersLookup(): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-employees-cost-center`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getCostCentersLookup(): Observable<any[]> {
    let url: string = `${this.controller}/get-lookup`;
    return this.getData(url);
  }

   getCostCentersByPost(postSearch: PostSearch): Observable<GenericResult<any>> {
     let url: string = `${this.controller}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllCostCenters(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getCostCenter(id: any): Observable<CostCenter> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<CostCenter>(url);
  }
  addCostCenter(item: CostCenter): Observable<CostCenter> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }
  updateCostCenter(item: any): Observable<any> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }
  deleteCostCenter(id: any): Observable<any> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
  

}
