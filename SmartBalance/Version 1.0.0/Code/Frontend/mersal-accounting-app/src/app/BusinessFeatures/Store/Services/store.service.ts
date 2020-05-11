import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { BaseService } from '../../../SharedFeatures/SharedMain/Services/base.service';
import { GenericResult } from '../../../SharedFeatures/SharedMain/Models/generic-result.model';
import { User } from '../../../BusinessFeatures/User/Models/user.model';
import {CurrentUserService} from '../../User/Services/current-user.service';
import { TranslateService } from '@ngx-translate/core';
import { StoreStartBalance } from '../Models/opening-balance.model';
import { InventoryTransfer } from '../Models/inventory-transfer.model';
import { InventoryMovement } from '../Models/inventory-movement.model';


@Injectable({
  providedIn: 'root'
})
export class StoreService extends BaseService {

  private controller: string = `${this.backendServerUrl.baseApiUrl}OpeningBalance`;
  constructor(
    private http: HttpClient,
    private currentUserService: CurrentUserService,
    private translateService: TranslateService
    ) {
    super(http, currentUserService, translateService);
  }

  getStoreLookup(): Observable<any[]> {
    let url: string = `${this.controller}/get-lookup`;
    return this.getData(url);
  }

  getProductByInventoryId(id: any): Observable<any[]> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Inventorys/get-Inventory-Product/${id}`;
    return this.getData<any[]>(url);
  }

  getOpeningBalance(id: any): Observable<StoreStartBalance> {
    let url: string = `${this.backendServerUrl.baseApiUrl}OpeningBalance/get-opening-balances/${id}`;
    return this.getData<StoreStartBalance>(url);
  }
  addOpeningBalance(model: StoreStartBalance): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}OpeningBalance/add-opening-balances`;
    return this.postData(url, model);
  }
  updateOpeningBalance(model: StoreStartBalance): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}OpeningBalance/update-opening-balances`;
    return this.postData(url, model);
  }
  addInventoryTransfer(model: InventoryTransfer): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryTransfers/add-inventory-transfer`;
    return this.postData(url, model);
  }
  updateInventoryTransfer(model: InventoryTransfer): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryTransfers/update-inventory-transfer`;
    return this.postData(url, model);
  }
  getInventoryTransfer(id: any): Observable<InventoryTransfer> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryTransfers/get-inventory-transfer/${id}`;
    return this.getData<InventoryTransfer>(url);
  }
  getInventoryMovement(id: any): Observable<InventoryMovement> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryMovements/get-inventory-movement/${id}`;
    return this.getData<InventoryMovement>(url);
  }
  addInventoryMovement(model: InventoryMovement): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryMovements/add-inventory-movement`;
    return this.postData(url, model);
  }
  updateInventoryMovement(model: InventoryMovement): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryMovements/update-inventory-movement`;
    return this.postData(url, model);
  }

  getJournalEntriesByPost(postSearch: any): Observable<any> {
    let url: string = `${this.controller}/get-with-filter`;
    return this.postData(url, postSearch);
  }
  getInventoryTransferList(postSearch: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryTransfers/get-with-filter`;
    return this.postData(url, postSearch);
  }
  getInventoryMovementList(postSearch: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryMovements/get-with-filter`;
    return this.postData(url, postSearch);
  }
  getMovementTypeList(): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}InventoryMovementType/get-lookup`;
    return this.getData<InventoryTransfer>(url);
  }
  deleteProduct(id: any): Observable<any> {
    let url: string = `${this.backendServerUrl.baseApiUrl}Products/delete/${id}`;
    return this.deleteData<any>(url);
  }

}
