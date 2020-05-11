import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { CurrentUserService } from '../../User/Services/current-user.service';
import { AssetInventory, FixedAssetLight } from '../Models/fixed-asset.model';
import { PostSearch } from '../Models/search.model';

@Injectable({
  providedIn: 'root'
})
export class AssetInventoryService extends BaseService {

  private assetInventoryController: string = `${this.backendServerUrl.baseApiUrl}AssetInventorys`;
  private assetController: string = `${this.backendServerUrl.baseApiUrl}Assets`;


  constructor(
    http: HttpClient,
    currentUserService: CurrentUserService,
    translateService: TranslateService
  ) {
    super(http, currentUserService, translateService);
  }
 

  getassetInventorysLookups(): Observable<GenericResult<any>> {
    let url: string = `${this.assetInventoryController}/get-Lookup`;
    return this.getAllData<GenericResult<any>>(url);
  }
   getassetInventorysByPost(postSearch: any): Observable<GenericResult<any>> {
     let url: string = `${this.assetInventoryController}/get-with-filter`;
     return this.postData<GenericResult<any>>(url, postSearch);
   }
  getAllassetInventorys(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.assetInventoryController}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }
  getassetInventory(id: any): Observable<AssetInventory> {
    let url: string = `${this.assetInventoryController}/get/${id}`;
    return this.getData<AssetInventory>(url);
  }
  addassetInventory(item: AssetInventory): Observable<AssetInventory> {
    let url: string = `${this.assetInventoryController}/add`;
    return this.postData(url, item);
  }
  updateassetInventory(item: any): Observable<any> {
    let url: string = `${this.assetInventoryController}/update`;
    return this.postData(url, item);
  }
  deleteassetInventory(id: any): Observable<any> {
    let url: string = `${this.assetInventoryController}/delete/${id}`;
    return this.deleteData(url);
  }
  getAssetDetailsByLocation(id: any): Observable<any[]> {
    let url: string = `${this.assetController}/get-asset-details-by-location/${id}`;
    return this.deleteData(url);
  }
}
