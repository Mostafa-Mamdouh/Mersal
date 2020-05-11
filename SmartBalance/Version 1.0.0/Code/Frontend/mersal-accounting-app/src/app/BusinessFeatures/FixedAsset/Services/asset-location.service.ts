import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { AssetLocation, AssetLocationLight } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class AssetLocationService extends BaseService {

  private assetLocationController: string = `${this.backendServerUrl.baseApiUrl}AssetLocations`; 


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getassetLocationsLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.assetLocationController}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getassetLocationsByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.assetLocationController}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllassetLocations(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.assetLocationController}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getassetLocation(id: any): Observable<AssetLocation> {
    let url: string = `${this.assetLocationController}/get/${id}`;
    return this.getData<AssetLocation>(url);
  }
  // addassetLocation(item: AssetLocation): Observable<AssetLocation> {
  //   let url: string = `${this.assetLocationController}/add`;
  //   return this.postData(url, item);
  // }
  updateassetLocation(item: any): Observable<any> {
    let url: string = `${this.assetLocationController}/update`;
    return this.postData(url, item);
  }
  deleteassetLocation(id: any): Observable<any> {
    let url: string = `${this.assetLocationController}/delete/${id}`;
    return this.deleteData(url);
  }
}
