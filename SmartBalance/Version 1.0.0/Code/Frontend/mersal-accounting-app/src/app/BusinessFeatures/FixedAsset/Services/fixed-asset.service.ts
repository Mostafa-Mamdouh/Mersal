import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { FixedAsset, FixedAssetLight } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class FixedAssetService extends BaseService {

  private fixedAssetController: string = `${this.backendServerUrl.baseApiUrl}Assets`;
  private depreciationRatesController: string = `${this.backendServerUrl.baseApiUrl}DepreciationRates`;
  private depreciationTypesController: string = `${this.backendServerUrl.baseApiUrl}DepreciationTypes`

  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getFixedAssetsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.fixedAssetController}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getFixedAssetsByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.fixedAssetController}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllFixedAssets(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.fixedAssetController}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getFixedAsset(id: any): Observable<FixedAsset> {
    let url: string = `${this.fixedAssetController}/get/${id}`;
    return this.getData<FixedAsset>(url);
  }
  addFixedAsset(item: FixedAsset): Observable<FixedAsset> {
    let url: string = `${this.fixedAssetController}/add`;
    return this.postData(url, item);
  }
  updateFixedAsset(item: any): Observable<any> {
    let url: string = `${this.fixedAssetController}/update`;
    return this.postData(url, item);
  }
  deleteFixedAsset(id: any): Observable<any> {
    let url: string = `${this.fixedAssetController}/delete/${id}`;
    return this.deleteData(url);
  }
  getdepreciationRatesLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.depreciationRatesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getdepreciationTypeLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.depreciationTypesController}/get-light-by-pagger/${null}/${null}`;
    return this.getAllData<GenericResult<any>>(url);
  }
}
